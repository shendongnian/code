    Dictionary<string, string> test = new Dictionary<string,string>();
    test.Add("1", "blue");
    test.Add("2", "blue");
    test.Add("3", "green");
    test.Add("4", "red");
    Dictionary<string, string> test2 = new Dictionary<string, string>();
    foreach (KeyValuePair<string, string> entry in test)
    {
        if (!test2.ContainsValue(entry.Value))
            test2.Add(entry.Key, entry.Value);
    }
