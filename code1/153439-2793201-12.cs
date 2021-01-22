    var indexedAvailable = available.GroupBy(i => i.Name)
                                    .SelectMany(g => g.Select((itm, idx) => new 
                                                  { Name = itm.Name, Index = idx }));
    var indexedSelected = selected.GroupBy(i => i.Name)
                                  .SelectMany(g => g.Select((itm, idx) => new
                                                  { Name = itm.Name, Index = idx }));
