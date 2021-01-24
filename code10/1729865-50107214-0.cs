    public ActionResult GetSomething(int? id)
    {
        String cacheFilePath = Path.Combine( AppDomain.CurrentDomain.BaseDirectory, "Cache" );
        FileCache cache = new FileCache( cacheFilePath, false, TimeSpan.FromSeconds(30) );
        String cacheKey = String.Format( CultureInfo.InvariantCulture, "CacheKey{0}", id );
        if( purgeCache ) cache.Remove( cacheKey );
        String valueString = this.GenerateString( id );
        String myString = (String)cache.AddOrGetExisting( cacheKey, valueString, new CacheItemPolicy() { AbsoluteExpiration = DateTimeOffset.Now.AddSeconds(30) });
        return new JsonStringResult( myString );
    }
