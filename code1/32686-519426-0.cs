    public static readonly IDictionary<string, string> myDictionary = new Dictionary<string, string>();
    
    static ClassConstructor()
    {
        myDictionary.Add("key1", "value1");
        myDictionary.Add("key2", "value2");
        myDictionary.Add("key3", "value3");
    }
