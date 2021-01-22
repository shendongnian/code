    Dictionary<T, List<K>> dict = new Dictionary<T, List<K>>();
    //Insert item
    if (!dict.ContainsKey(key))
       dict[key] = new List<string>();
    dict[key].Add(value);
