    public IEnumerable<string> ReadRegistryKeys()
    {
        IEnumerable<string> resultList = new List<string>();
        if (string.IsNullOrEmpty(read_in_key_#1())
        {
            
            resultList.Add("Failed to load key 'blah'..");
        }
        
        if (.... read in the next key .. etc.... ) ...
    
        return resultList == null || resultList.Count <= 0 ? null : resultList;
    }
