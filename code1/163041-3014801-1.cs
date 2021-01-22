    public bool ShouldAddValue(Dictionary someDictionary, object id,object actualValue)
    {
        string id;
        string actual;
        string stored;
        
    
        if (someDictionary.TryGetValue (id, out stored)) 
        {
            if (stored != actual)
                return true;
        }
        else
        {
            return true;
        }
    }
