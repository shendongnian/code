    // Build a dictionary of the items that group
    var onesToGroup = list.Where(x => x.GroupThisClass)
                                .GroupBy(x => x.GetType())
                                .ToDictionary(x => x.Key, x => x.AsEnumerable());
        
    var results = list.SelectMany(x => x.GroupThisClass ?
                                 (onesToGroup[x.GetType()].First() == x ? onesToGroup[x.GetType()] : (new BaseClass[]{}))
                                                    : (new []{x}));
