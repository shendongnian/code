    public static void AddIfNotPresent<TKey, TValue>
           (this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)    
    {       
        if (!dictionary.ContainsKey(key)) dictionary.Add(key, value);
    }   
 
    public static void Test()    
    {        
         IDictionary<string, string> test = new Dictionary<string, string>(); 
         test.AddIfNotPresent("hi", "mom");    
    }
