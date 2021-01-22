    int weightLimit = 35;
    int fooGroup = 0;
    int totalWeight = 0;
    
    Func<Foo, int> groupIncrementer = f =>
    {
        if (totalWeight + f.Weight > weightLimit)
        {
            fooGroup++;
            totalWeight = 0;
        }
    
        totalWeight += f.Weight;
    
        return fooGroup;
    };
    
    var query = from foo in foos
                group foo by new { Group = groupIncrementer(foo) }
                    into g
                    select g.AsEnumerable();
    
    foreach (IList<Foo> list in query)
    {
        Console.WriteLine("{0}\t{1}", list.Count, list.Sum(f => f.Weight));
    }
