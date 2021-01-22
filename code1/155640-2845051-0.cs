    //setup date ranges to use
    DateTime startDate = DateTime.Now.AddDays(-29);
    DateTime endDate = DateTime.Now.AddDays(1);
    TimeSpan startTS = new TimeSpan(0, 0, 0);
    TimeSpan endTS = new TimeSpan(23, 59, 59);
    using (var dc = new DataContext())
    {
        //get database sales from 29 days ago at midnight to the end of today
        var salesForPeriod = dc.Orders.Where(b => b.OrderDateTime > Convert.ToDateTime(startDate.Date + startTS) && b.OrderDateTime <= Convert.ToDateTime(endDate.Date + endTS));
        var query = from s in salesForPeriod
                    group s by s.OrderDateTime.Date into g
                    select new {Day = g.Key, totalSales = g.Sum(x=>(decimal)x.OrderPrice);
    }
