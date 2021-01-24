    var r1 = new FilterDateTimeRange(DateTime.Now.AddDays(-1).Date, DateTime.Now.AddDays(-1).Date);
    var r = new FilterDateRange(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1));
    
    var r1a = Accounts.Where(r1.RangeFilter<Accounts>(a => a.Modified_date));
    var ra = Accounts.WhereInRange(r, a => a.Modified_date);
