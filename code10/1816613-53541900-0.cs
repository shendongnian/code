    var counts = numbers.GroupBy(v => v)
                        .Select(g => g.Key, Count = g.Count())
                        .OrderByDescending(g => g.Count);
    var modes = numbers.Where(g => g.Count == counts.First().Count)
                       .Select(g => g.Key);
