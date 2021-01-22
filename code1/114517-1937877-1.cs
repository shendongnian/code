    // we need to cache the keys to update since we can't
    // modify the collection during enumeration
    var keysToUpdate = new List<int>();
    
    foreach (var entry in dict)
    {
        if (entry.Key < MinKeyValue)
        {
            keysToUpdate.Add(entry.Key);
        }
    }
    
    foreach (int keyToUpdate in keysToUpdate)
    {
        SortedDictionary<string, List<string>> value = dict[keyToUpdate];
    
        int newKey = keyToUpdate + 1;
        
        // increment the key until arriving at one that doesn't already exist
        while (dict.ContainsKey(newKey))
        {
            newKey++;
        }
        
        dict.Remove(keyToUpdate);
        dict.Add(newKey, value);
    }
