    Dictionary<int, string> dict = new Dictionary<int, string>();
    
    dict.Add(1, "One");
    dict.Add(2, "Two");
    dict.Add(3, "Three");
    dict.Add(4, "Four");
    dict.Add(5, "Five");
    
    object dictObj = (object)dict;
    
    IDictionary temp = (IDictionary)dictObj;
    
    Dictionary<int, object> objs = new Dictionary<int, object>();
    
    foreach (DictionaryEntry de in temp)
    {
    	objs.Add((int)de.Key, (object)de.Value);
    }
