    int i = 0; // Used as group index.
    (int Index, string LN, string M) prev = default; // Stores previous key for later comparison.
    var modified = original
        .GroupBy(mt => {
            var ret = (Index: prev.LN == mt.LineName && prev.M == mt.Mode ? i : ++i,
                       LN: mt.LineName, M: mt.Mode);
            prev = (Index: i, LN: mt.LineName, M: mt.Mode);
            return ret;
        })
        .Select(g => new ModeTime {
            Date = g.Min(mt => mt.Date),
            LineName = g.Key.LN,
            Mode = g.Key.M,
            Time = new TimeSpan(g.Sum(mt => mt.Time.Ticks))
        })
        .ToList();
