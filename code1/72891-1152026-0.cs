    public ObjectLoader(ref Cache cache) {
   
        _cache = cache; // store        
        // do something very odd!
        cache = new Cache();
    }
