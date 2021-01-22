    var table = new Dictionary<string, int>() {{"first", 1}, {"second", 2}};
    for (int i = 0; i < table.Keys.Count; i++)//string key in table.Keys)
    {
        string key = table.Keys.ElementAt(i);
        if (key.StartsWith("f"))
        {
            table.Remove(key);
        }
    }
