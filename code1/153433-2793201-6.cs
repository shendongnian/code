    var indexedAvailable = available.GroupBy(i => i.Name)
                                    .Select(g => g.Select((itm, idx) => new 
                                                  { Name = itm.Name, Index = idx }))
                                    .Aggregate(Enumerable.Concat);
    var indexedSelected = selected.GroupBy(i => i.Name)
                                  .Select(g => g.Select((itm, idx) => new
                                                   { Name = itm.Name, Index = idx }))
                                  .Aggregate(Enumerable.Concat);
