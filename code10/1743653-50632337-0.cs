    var amp = master.Aggregate(
        new List<List<string>>(){new List<string>()},
        (a, b) => a.Aggregate(
            new List<List<string>>(new List<List<string>>()),
            (r, v) => r.Concat(
                b.Select(w => v.Concat(new List<string>{w}).ToList())
            ).ToList()));
