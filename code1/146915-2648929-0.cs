    context.MyRecords
    
        // tz adjusted, projection
       .Select(r => new {original = r.TimeStamp, adjusted = r.TimeStamp.AddHours(tz)})
    
       // group by start of month
       .GroupBy (r => r.adjusted.Date.AddDays(-r.Day))
    
       // final projection from groups to values asked for
       .Select (g => new {count = g.Count(), year = g.Key.Year, month = g.Key.Month})
