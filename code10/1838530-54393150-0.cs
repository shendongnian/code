    var keys = new ConcurrentDictionary<DateTime, DateTime>();
    var dataDictionary = new ConcurrentDictionary<DateTime, FullData>();
    sources
        .Merge()
        .GroupByUntil(data => data.currentDate, s => s.Any(data => !data.IsValid)) // group by currentDate until an invalid data appears in the group (the last invalid data can be in this group)
        .Where(g => keys.TryAdd(g.Key, g.Key)) // skip the reborned groups for the same key (they are created because of durationSelector, which controls the lifetime of a group)
        .Merge() // switch to the previous flattened structure
        .Where(data => data.IsValid) // remove the last invalid item emitted by GroupByUntil
        .Subscribe(x =>
        {
            var fullData = dataDictionary.GetOrAdd(x.currentDate, f => new FullData { currentDate = x.currentDate, Samples = new List<List<double>>() });
            fullData.Samples.Add(x.Samples);
            Console.WriteLine($"received: {x.currentDate.ToLocalTime()} {x.IsValid} {string.Join(", ", x.Samples)}");
        }, () => Console.WriteLine("Completed"));
    Console.ReadKey();
    foreach (var item in dataDictionary)
    {
        Console.WriteLine($"{item.Key.ToLocalTime()}, {string.Join(",", item.Value.Samples.SelectMany(t => t))}");
    }
