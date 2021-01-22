    Dictionary<int,string> dictionary = new Dictionary<int,string>();
    int key = 0;
    dictionary[key] = "Yes";
    string value;
    if (dictionary.TryGetValue(key, out value))
    {
        Console.WriteLine("Fetched value: {0}", value);
    }
    else
    {
        Console.WriteLine("No such key: {0}", key);
    }
