    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Product> Products = new List<Product>();
                List<Order> Orders = new List<Order>();
                var results = (from o in Orders
                              join p in Products on o.ProductID equals p.ProductID
                              select new {order = o, name = p.ProductName})
                              .OrderByDescending(x => x.order.orderDate)
                              .GroupBy(x => x.order.ProductID)
                              .Select(x => x.FirstOrDefault())
                              .Where(x => x.order.orderDate < DateTime.Now.AddMonths(-6))
                              .Select(x => new { Name = x.name, ID = x.order.ProductID, Date = x.order.orderDate})
                              .ToList();
            }
        }
        public class Product
        {
            public string ProductName { get; set; }
            public string ProductID { get; set; }
        }
        public class Order
        {
            public DateTime orderDate { get; set; }
            public string ProductID { get; set; }
        }
    }
