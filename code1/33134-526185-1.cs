    List<string> a = new List<string> { "A1", "A2", "A3" };
    List<string> b = new List<string> { "B1", "B2", "B3" };
    ChainedEnumerable<string> chainedEnumerable =
        new ChainedEnumerable<string>(a, b);
    foreach (string s in chainedEnumerable)
        Console.WriteLine(s);
