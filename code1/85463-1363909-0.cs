    // before serialization
    IDictionary<string,int> dict;
    string[] keys = dict.Keys.ToArray();
    int[] values = dict.Keys.Select(key => dict[key]).ToArray();
    
    // after deserialization
    IDictionary<string,int> dict = new Dictionary<string,int>();
    for (int i = 0; i < keys.Length; i++)
        dict.Add(keys[i], values[i]);
