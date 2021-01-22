    var dictionary = new OpenDictionary<string, int>();
    dictionary.Add("1", 1); 
    // The next line won't throw an exception; 
    dictionary.Add("1", 2);
    dictionary.TryGetEntries("1", out List<int> result); 
    // result is { 1, 2 }
    dictionary.Add(null, 42);
    dictionary.Add(null, 24);
    dictionary.TryGetEntries(null, out List<int> result); 
    // result is { 42, 24 }
