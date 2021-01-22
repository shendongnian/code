    var result = from tick in listTicks
    group tick by (tick.timestamp - DateTime.MinValue).TotalMinutes / 15 into f
    from c in f
    select new { StartTime = DateTime.MinValue + TimeSpan.FromMinutes(c.Key),
                 Items = ... };
