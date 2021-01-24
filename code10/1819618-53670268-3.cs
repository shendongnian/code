    private static void Add(Dictionary<string, List<string>> d, string key, string value)
    {
        if (!d.TryGetValue(key, out var list))
            d[key] = list = new List<string>();
        list.Add(value);
    }
