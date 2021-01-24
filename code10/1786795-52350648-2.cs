    var values2 = values
        .Distinct()
        .GroupBy(x => new Key(x.UnitPoints, x.Texts), new Comparer())
        .Select(x => new
        {
            x.Key.UnitPoints,
            Texts = x.Key.Texts,
            Site = x.Select(y => y.SiteName)
        }).ToList();
