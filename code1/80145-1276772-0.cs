        Dictionary<string, int> data = new Dictionary<string, int>();
        data.Add("abc", 123);
        data.Add("def", 456);
        foreach (string key in data.Keys)
        {
            Console.WriteLine(key);
        }
