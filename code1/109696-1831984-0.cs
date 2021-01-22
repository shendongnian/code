    string xmlUrl = "http://myserver.com/xmlfile.xml";
    
    WebClient client = new WebClient();
    
    // prevent file caching by windows
    client.CachePolicy = new System.Net.Cache.RequestCachePolicy(
    System.Net.Cache.RequestCacheLevel.NoCacheNoStore
    );
    
    // read content of file
    Stream rssStream = client.OpenRead(xmlUrl);
