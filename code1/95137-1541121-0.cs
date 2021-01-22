    class Program
    {
        static void Main(string[] args)
        {
            var sales = new List<Sale>();
            sales.Add(new Sale() { Product = "soap", saleDate = new DateTime(2009, 10, 22), Quantity = 10});
            sales.Add(new Sale() { Product = "soap", saleDate = new DateTime(2009, 9,22), Quantity = 6});
            sales.Add(new Sale() { Product = "pills", saleDate = new DateTime(2009,9,25), Quantity = 15});
            sales.Add(new Sale() { Product = "pills", saleDate = new DateTime(2009,9,25), Quantity = 5});
    
            var q = from s in sales
                    group s by new { s.Product, s.saleDate.Month, s.saleDate.Year } into g
                    select new {Month = String.Format("{0:MM/yy}", new DateTime(g.Key.Year, g.Key.Month, 1)), product = g.Key.Product, quantity = g.Sum(o=>o.Quantity)};
    
    
        }
    }
    
    class Sale
    {
        public DateTime saleDate { get; set; }
        public int Quantity { get; set; }
        public string Product { get; set; }
    }
