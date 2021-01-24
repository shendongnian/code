    var dictionary = new Dictionary<string, KeyValuePair<string, int>>(StringComparer.OrdinalIgnoreCase)
    {
        // You'd normally write a helper method to avoid having to specify
        // the key twice, of course.
        {"abc1", new KeyValuePair<string, int>("abc1", 1)},
        {"abC2", new KeyValuePair<string, int>("abC2", 2)},
        {"abc3", new KeyValuePair<string, int>("abc3", 3)}
    };
    if (dictionary.TryGetValue("Abc2", out var entry))
    {
        Console.WriteLine(entry.Key); // abC2
        Console.WriteLine(entry.Value); // 2
    }
    else
    {
        Console.WriteLine("Key not found"); // We don't get here in this example
    }
