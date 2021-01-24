    public void AddHeaders(T collection) Where T is HttpRequestHeaders
    {
    collection.Add("key1", 111);
    collection.Add("key2", 222);
    collection.Add("key3", 333); 
    }
    
    public void AddHeaders(T collection) Where T is WebHeaderCollection
    {
    collection.Add("key1", 111);
    collection.Add("key2", 222);
    collection.Add("key3", 333); 
    }
