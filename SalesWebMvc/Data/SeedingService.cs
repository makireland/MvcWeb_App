using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any())
            {
                return; //Db has been seeded
            }

            var d1 = new Department(1, "Compurter");
            var d2 = new Department(2, "Electronics");
            var d3 = new Department(3, "Books");
            var d4 = new Department(4, "Fashion");

            var s1 = new Seller(1, "Bob Brow", "bob@gmail.com", 1000.00, new DateTime(1984, 4, 21), d4);

            var sr1 = new SalesRecord(1, new DateTime(2018, 09, 25), 11000.0, SaleStatus.Billed, s1);

            _context.Department.AddRange(d1, d2, d3, d4);

            _context.Seller.AddRange(s1);

            _context.SalesRecord.AddRange(sr1);

            _context.SaveChanges();
        }
    }
}
