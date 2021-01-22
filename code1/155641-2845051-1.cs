    //setup date ranges to use
    DateTime startDate = DateTime.Now.AddDays(-29);
    DateTime endDate = DateTime.Now.AddDays(1);
    using (var dc = new DataContext())
    {
        //get database sales from 29 days ago at midnight to the end of today
        var salesForPeriod = dc.Orders.Where(b => b.OrderDateTime > startDate.Date  && b.OrderDateTime <= endDate.Date);
        
        var query = from s in salesForPeriod
                    group s by s.OrderDateTime.Date into g
                    select new {Day = g.Key, totalSales = g.Sum(x=>(decimal)x.OrderPrice);
        var results = new Dictionary<DateTime, decimal>();
        
        for (DateTime d = startDate; d != endDate, d.AddDays(1))
        {
            var values = query.Single(x=>x.Day == d) ?? new {Day = d, totalSales = 0m};
            results.Add(d, values.totalSales);
        }
}
