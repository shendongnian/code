    var dictionary = new Dictionary<string, List<object>>();
    for (int i = 1; i <= 2; i++)
    {
        if (!dictionary.TryGetValue("Key1", out List<object> list))
        {
            list = new List<object>();
            dictionary["Key1"] = list;
        }
        list.Add(i);
    }
