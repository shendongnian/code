    Dictionary<T, U> source = GetDictionary();
    List<IGrouping<U, T> valueGroupList = source
      .GroupBy(kvp => kvp.Value, kvp => kvp.Key)
      .ToList();
    
    Dictionary<T, U> withoutDupes = valueGroupList
      .Where(g => !g.Skip(1).Any())
      .ToDictionary(g => g.First(), g.Key);
    
    Dictionary<U, int> dupesWithCount = valueGroupList
      .Where(g => g.Skip(1).Any())
      .ToDictionary(g.Key, g.Count())
