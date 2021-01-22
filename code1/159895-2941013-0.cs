    Dictionary<int, string> dictionary = new Dictionary<int, string>();
    dictionary.Add(1, "Alpha");
    dictionary.Add(2, "Bravo");
    dictionary.Add(3, "Charlie");
    dictionary.Add(4, "Alpha");
    dictionary.Add(5, "Bravo");
    dictionary.Add(6, "Alpha");
    var uniqueItems = dictionary
        .GroupBy(kvp => kvp.Value)
        .Select(g => new { g.Key, Count = g.Count() })
        .ToDictionary(g => g.Key, g => g.Count);
    foreach (var kvp in uniqueItems)
    {
        Console.WriteLine("{0}\t{1}", kvp.Key, kvp.Value);
    }
