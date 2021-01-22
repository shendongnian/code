    List<string> names = new List<string>();
    names.AddRange(new string[]{"John","Frank","Jeff","George","Bob","Grant", "McLovin"});
    foreach (string name in names.Page(2, 2))
    {
        Console.WriteLine(name);
    }
