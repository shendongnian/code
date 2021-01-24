    var arrays = new[]
    {
        new[] {"A", "B", "C", "D", "E", "F"},
        new[] {"A", "B", "B", "C", "D", "D", "D", "E", "F"},
        new[] {"A", "B", "B", "C", "D", "D", "E", "F"},
        new[] {"A", "B", "B", "B", "C", "D", "D", "E", "F"},
        new[] {"A", "B", "B", "C", "D", "E", "E", "F"},
    };
    var result = new List<string>();
    foreach (var array in arrays)
    {
        var distinctItems = array.Distinct();
        foreach (var distinctItem in distinctItems)
        {
            var diff = array.Count(i => i == distinctItem) - 
                       result.Count(i => i == distinctItem);
            if (diff > 0) result.AddRange(Enumerable.Repeat(distinctItem, diff));
        }
    }
    Console.WriteLine(string.Join(", ", result.OrderBy(i => i)));
