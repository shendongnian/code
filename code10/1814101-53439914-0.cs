    public string GetDictionaryKey(string[] targetValue)
    {
    	List<string[]> valuesList = new List<string[]>();
    	List<string> keysList = new List<string>();
    
    	var values = AnimalDictionary.Values;
    	var keys = AnimalDictionary.Keys;
    
    
    	foreach (string[] value in values)
    	{
    		valuesList.Add(value);
    	}
    
    	foreach (string key in keys)
    	{
    		keysList.Add(key);
    	}
    
    	var entry = values.FirstOrDefault(r => r.SequenceEqual(targetValue));
    
    	int valueIndex = valuesList.IndexOf(entry);
    
    	return keysList[valueIndex];
    }
