    var list = new List<(string,string)>();
    list.Add(("10", "a"));
    list.Add(("20", "b"));
    
    // order one way
    foreach (var item in list.OrderBy(x => x.Item1))
       Console.WriteLine(item);
    
    // order another
    foreach (var item in list.OrderByDescending(x => x.Item1))
       Console.WriteLine(item);
