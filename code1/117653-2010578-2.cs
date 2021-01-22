    var query = list.Select(x => x.Names)
                    .SelectMany(set => set.Select(s => s))
                    .GroupBy(s)
                    .Select(g => new { Name = g.Key, Count = g.Count() });
    foreach(var result in query) {
        Console.WriteLine("Name: {0}, Count: {1}", result.Name, result.Count);
    }
