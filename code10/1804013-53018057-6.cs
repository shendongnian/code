    var dict = new Dictionary<string, float>();
    var result = new KeyValuePair<string, float>[dict.Count];
    var values = new float[dict.Count];
    var keys = new string[dict.Count];
    dict.Values.CopyTo(values, 0);
    dict.Keys.CopyTo(keys, 0);
    
    for (var i = 0; i < dict.Count; i++)
    {
       result[i] = new KeyValuePair<string, float>(keys[i], values[i]);
    }
    
    var sortDesc = new SortDesc();
      
    Array.Sort(result, sortDesc);
