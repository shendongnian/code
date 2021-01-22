    //Using extension methods
    var q = list.GroupBy(x => x.Name)
                .Select(x => new {Count = x.Count(), 
                                  Name = x.Key, 
                                  ID = x.First().ID})
                .OrderByDescending(x => x.Count);
    //Using LINQ
    var q = from x in list
            group x by x.Name into g
            let count = g.Count()
            orderby count descending
            select new {Name = g.Key, Count = count, ID = g.First().ID};
    foreach (var x in q)
    {
        Console.WriteLine("Count: " + x.Count + " Name: " + x.Name + " ID: " + x.ID);
    }
