    public class OrderCollectionDetails
    {
        public DateTime ForDate { get; set; }
        public double TotalSales { get; set; }
        public int OrderCount { get; set; }
    }
    public class OrderDetails
    {
        public DateTime OrderDate { get; set; }
        public double Sales { get; set; }
    }
        static void Main(string[] args)
        {
            List<OrderDetails> orders = new List<OrderDetails>();
            orders.Add(new OrderDetails() { OrderDate  = DateTime.Parse("12/14/2018 3:00"), Sales = 10 });
            orders.Add(new OrderDetails() { OrderDate  = DateTime.Parse("12/14/2018 3:30"), Sales = 20.5 });
            orders.Add(new OrderDetails() { OrderDate  = DateTime.Parse("12/14/2018 3:40"), Sales = 55.23 });
            orders.Add(new OrderDetails() { OrderDate = DateTime.Parse("12/14/2018 4:00"), Sales = 1.11 });
            var orderGrp = orders.GroupBy(o => new DateTime(o.OrderDate.Year, o.OrderDate.Month, o.OrderDate.Day, o.OrderDate.Hour, 0, 0));
            List<OrderCollectionDetails> details = new List<OrderCollectionDetails>();
            foreach(var grp in orderGrp)
            {
                var firstItm = grp.FirstOrDefault();
                var targetDate = new DateTime(firstItm.OrderDate.Year, firstItm.OrderDate.Month, firstItm.OrderDate.Day, firstItm.OrderDate.Hour, 0, 0);
                details.Add(new OrderCollectionDetails()
                {
                    ForDate = targetDate,
                    OrderCount = grp.Count(),
                    TotalSales = grp.Sum(g => g.Sales)
                });
            }
        }
