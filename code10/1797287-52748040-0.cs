    var dates = new List<DateTime>{ ... }; // dates get initialized however your code does it...
    
    var groups = dates.Select(d => 
        d, 
        GroupDate = new DateTime(d.Year, d.Month, d.Day, d.Hour, (d.Minute / 5) * 5, d.Second)})
        .GroupBy(g => g.GroupDate);
