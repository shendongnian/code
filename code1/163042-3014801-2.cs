    public bool ShouldAddValue(Dictionary someDictionary, object id,object actualValue)
    {
        string stored;
            
        if (someDictionary.TryGetValue (id, out stored)) 
        {
            if (stored != actualValue)
                return true;
        }
        else
        {
            return true;
        }
    }
