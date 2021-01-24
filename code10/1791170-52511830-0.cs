    var RootFilter = new HttpBaseProtocolFilter();
    
    RootFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
    RootFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
    
    var HttpClient = new HttpClient(RootFilter);
