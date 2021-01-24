    sources.Merge().ToList().Subscribe(list =>
    {
        var fullDataList = list
            .GroupBy(data => data.currentDate)
            .Where(g => g.All(data => data.IsValid))
            .Select(g => new FullData { currentDate = g.Key, Samples = g.Select(data => data.Samples).ToList() });
        foreach (var fullDataItem in fullDataList)
        {
            Console.WriteLine($"{fullDataItem.currentDate.ToLocalTime()}, {string.Join(",", fullDataItem.Samples.SelectMany(t => t))}");
        }
    });
