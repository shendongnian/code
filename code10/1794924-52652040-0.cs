    var input = new[]
    {
        new A {Id = 1, Date = new DateTime(2018, 10, 3), TypeId = 1, Version = 1},
        new A {Id = 2, Date = new DateTime(2018, 10, 3), TypeId = 1, Version = 2},
        new A {Id = 3, Date = new DateTime(2018, 10, 4), TypeId = 1, Version = 1},
        new A {Id = 4, Date = new DateTime(2018, 10, 4), TypeId = 2, Version = 1},
    };
    var result = input.Where(a => a.Version == 1)
        .GroupBy(a => a.TypeId)
        .Select(g => g.OrderByDescending(x => x.Date).First())
        .ToArray();
