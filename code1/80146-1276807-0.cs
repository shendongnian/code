    Dictionary<string, int> data = new Dictionary<string, int>();
    data.Add("abc", 123);
    data.Add("def", 456);
    
    foreach (KeyValuePair<string, int> item in data)
    {
        Console.WriteLine(item.Key + ": " + item.Value);
    }
