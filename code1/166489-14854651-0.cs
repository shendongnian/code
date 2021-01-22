    public static Dictionary<int, string> GetDictionaryFromEnum<T>()
    {
    
    	string[] names = Enum.GetNames(typeof(T));
    
    	Array keysTemp = Enum.GetValues(typeof(T));
    	dynamic keys = keysTemp.Cast<int>();
    
    	dynamic dictionary = keys.Zip(names, (k, v) => new {
    		Key = k,
    		Value = v
    	}).ToDictionary(x => x.Key, x => x.Value);
    
    	return dictionary;
    }
