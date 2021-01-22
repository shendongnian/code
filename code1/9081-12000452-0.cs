    // declaration
    var list = new List<Tuple<string, List<object>>>();
    // to add an item to the list
    var item = Tuple<string, List<object>>("key", new List<object>);
    list.Add(item);
    // to iterate
    foreach(var i in list)
    {
        Console.WriteLine(i.Item1.ToString());
    }
 
