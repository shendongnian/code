    var items = Db.Items.Where(s => s.Create <= min 
        && (!s.Close.HasValue || s.Close.Value >= max)).ToList();
    
    return EnumerateMonths(min, max).Select(m => new DataPoint
        {
            Date = m,
            Count = items.Where(s => s.Create <= m.AddMonths(1) && (!s.Close.HasValue || s.Close.Value >= m.AddMonths(1))).Count()
        }).ToList();
