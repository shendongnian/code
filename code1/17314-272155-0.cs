    Dictionary<string, decimal> adjDictionary = adjList
      .GroupBy(a => a.PropName)
      .ToDictionary(g => g.Key, g => g.Sum(a => a.AdjVal))
    
    propList.ForEach(p => 
      {
        decimal a;
        adjDictionary.TryGetValue(p.Name, out a);
        p.Total = p.Val + a;
      });
