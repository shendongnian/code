    // CacheFactory class provides methods to return cache objects
    // Create instance of CacheFactory (reads appconfig)
    DataCacheFactory fac = new DataCacheFactory();
    // Get a named cache from the factory
    DataCache catalog = fac.GetCache("catalogcache");
    //-------------------------------------------------------
    // Simple Get/Put
    catalog.Put("toy-101", new Toy("thomas", .,.));
    // From the same or a different client
    Toy toyObj = (Toy)catalog.Get("toy-101");
    // ------------------------------------------------------
    // Region based Get/Put
    catalog.CreateRegion("toyRegion", true);
    // Both toy and toyparts are put in the same region
    catalog.Put("toy-101", new Toy( .,.), "toyRegion");
    catalog.Put("toypart-100", new ToyParts(…), "toyRegion");
    Toy toyObj = (Toy)catalog.Get("toy-101", "toyRegion");
