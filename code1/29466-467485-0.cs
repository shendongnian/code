    List<List<string>> source = GetLists();
    //    
    Dictionary<string, int> result = source
      .SelectMany(sublist => sublist)
      .GroupBy(s => s)
      .ToDictionary(g => g.Key, g => g.Count())
