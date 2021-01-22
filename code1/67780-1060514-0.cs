    private void PopulateCacheB()
    {    
        Dictionary<int, MyObj>() dictionary = new Dictionary<int, MyObj>();    
        foreach (MyObj item in databaseAccessor)    
        {        
            dictionary.Add(item.Key, item);    
        }
        cacheB = dictionary;
    }
