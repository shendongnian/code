    Dictionary<int,string> dictionary = new Dictionary<int,string>();
    dictionary[0] = "Yes";
    string value;
    if (dictionary.TryGetValue(0, out value))
    {
        Console.WriteLine("Fetched value: {0}", value);
    }
    else
    {
        Console.WriteLine("No such key", value);
    }
