    // list is IEnumerable<int> (e.g., List<int>)
    var ordered = list.GroupBy(n => n)
                      .OrderByDescending(g => g.Count())
                      .Select(g => g.Key)
                      .ToList();
