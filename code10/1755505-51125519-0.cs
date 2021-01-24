    Dictionary<string, string> dict1 = new Dictionary<string, string>();
    dict1.Add("abc", "hello");
    dict1.Add("def", "world");
    
    Dictionary<string, string> dict2 = new Dictionary<string, string>();
    dict2.Add("hij", "bonjour");
    dict2.Add("abc", "le monde");
    
                
     Dictionary<string, string> dict3 = dict1
     .Where(kvp => !dict2.ContainsKey(kvp.Key))
     .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
