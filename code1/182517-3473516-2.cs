    var latestProducts = db.Releases
        .GroupBy(p => p.PlatformID)
        .Select(grp => new {
            Platform = grp.Key,
            Latest = grp.OrderByDescending(p => p.Date).FirstOrDefault()
        })
        .OrderByDescending(entry => entry.Latest.Date);
    foreach (var entry in latestProducts)
    {
        Console.WriteLine("The latest product for platform {0} is {1}.",
            entry.Platform,
            entry.Latest.ProductID);
    }
