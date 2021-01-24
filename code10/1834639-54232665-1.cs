    var input = new Dictionary<string, IList<TimeLapse>>
    {
        {
            "A",
            new[]
            {
                new TimeLapse{ StartTime = new DateTime(2019, 1, 17, 0, 0, 0), EndTime = new DateTime(2019, 1, 17, 3, 0, 0)},
                new TimeLapse{ StartTime = new DateTime(2019, 1, 17, 1, 0, 0), EndTime = new DateTime(2019, 1, 17, 2, 0, 0)},
                new TimeLapse{ StartTime = new DateTime(2019, 1, 17, 1, 0, 0), EndTime = new DateTime(2019, 1, 17, 4, 0, 0)},
                new TimeLapse{ StartTime = new DateTime(2019, 1, 17, 5, 0, 0), EndTime = new DateTime(2019, 1, 17, 7, 0, 0)}
            }
        },
        {
            "B",
            new TimeLapse [0]
        }
    };
    var result = input
        .Select(kv => new
        {
            Device = kv.Key,
            FaultyDuration = kv.Value
                // .OrderBy(tl => tl.StartTime) // this line can be removed if already ordered by StartTime
                .UnionDurations()
        })
        .ToList();
    // { Device = A, FaultyDuration = 06:00:00 }
    // { Device = B, FaultyDuration = 00:00:00 }
