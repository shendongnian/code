    var dates = 
        (from z in table
         select new { Year = z.LastYear, Month = z.LastMonth, Day = z.LastDay })
        .AsEnumerable()
        .Select(d => new 
            {
                Date = new DateTime(d.Year, d.Month, d.Day),
                NextDate = new DateTime(d.Year, d.Month, 1).AddMonths(2).AddDays(-1)
            });
