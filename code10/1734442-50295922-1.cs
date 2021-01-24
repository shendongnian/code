    string common = "Blue;Red;Red;Green;Green;Green;Blue;Blue;Blue;Yellow";
    var grouped = common.Split(';')
        .GroupBy(x => x)
        .Select(x => new {
            x.Key,
            Count = x.Count(),
        });
    foreach(var grouping in grouped)
    {
        Console.WriteLine($"{grouping.Key}: {grouping.Count}");
    }
