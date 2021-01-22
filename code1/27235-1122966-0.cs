    public Dictionary<string,int> CacheFields(IDataReader reader)
    {
     
        var cache = new Dictionary<string,int>();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            cache[reader.GetName(i)] = i;
        }
        return cache;
    }
