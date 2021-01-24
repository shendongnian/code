    var original = new List<ModeTime>();
    original.GroupBy(mt => new { mt.Date, mt.LineName, mt.Mode })
        .Select(g => new ModeTime {
            Date = g.Key.Date,
            LineName = g.Key.LineName,
            Mode = g.Key.Mode,
            Time = new TimeSpan(g.Sum(mt => mt.Time.Ticks))
        })
        .ToList();
