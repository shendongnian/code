    var dictionary = new Dictionary<string, int>
    {
        { "zero", 0 },
        { "one", 1 },
        { "two", 2 }
    };
    foreach(var pair in dictionary.Invert())
    {
        Console.WriteLine("{0}: {1}", pair.Key, pair.Value);
    }
    // 0: zero
    // 1: one
    // 2: two
