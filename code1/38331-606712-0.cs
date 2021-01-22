    var dictionaryA = dataA
      .GroupBy(item => new {a = item.a, b = item.b})
      .ToDictionary(g => g.Key, g => g.ToList());
    
    var dictionaryB = dataB
      .GroupBy(item => new {a = item.a, b = item.b})
      .ToDictionary(g => g.Key, g => g.ToList());
    
    var results = dictionaryA
      .Where(g1 => dictionaryB.ContainsKey(g1.Key))
      .Select(g1 => new {g1 = g1, g2 = dictionaryB[g1.Key]})
      .SelectMany(pair =>
        pair.g1.SelectMany(item1 =>
          pair.g2
          .Where(item2 => item2.c != item1.c)
          .Select(item2 => new {item1, item2})
        )
      );
