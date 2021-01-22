    var indexedItems = items.GroupBy(i => i.Name)
                            .Select(g => g.Select((itm, idx) => new 
                                                  { Name = itm.Name, Index = idx }))
                            .Aggregate(Enumerable.Concat);
    var indexedListing = listing.GroupBy(i => i.Name)
                                .Select(g => g.Select((itm, idx) => new
                                                   { Name = itm.Name, Index = idx }))
                                .Aggregate(Enumerable.Concat);
