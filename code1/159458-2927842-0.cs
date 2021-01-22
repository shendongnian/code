    IDictionary<Int32, String> dictionary = new Dictionary<Int32, String>();
    
    // Iterate over all key value pairs.
    foreach (KeyValuePair<Int32, String> keyValuePair in dictionary)
    {
        Int32  key = keyValuePair.Key;
        String value = keyValuePair.Value;
    }
    
    // Iterate over all keys.
    foreach (Int32 key in dictionary.Keys)
    {
        // Get the value by key.
        String value = dictionary[key];
    }
    
    // Iterate over all values.
    foreach (String value in dictionary.Values)
    {
    }
