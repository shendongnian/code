    public async Task<IEnumerable<Airport>> GetAirportDataAsync()
    {
        var cacheKey = "airport-data";
        var headerName = "from-feed";
        // Safe cast to IEnumerable - Get returns null if the item does not exist in the cache
        var data = MemoryCache.Default.Get(cacheKey) as IEnumerable<Airport>;
        if (data == null)
        {
            Response.Headers.Add(headerName, "true");
            // Utilize your existing logic to get the data from the API
            data = await getAirportDataFromApiAsync();
            // Only cache for 5 minutes by providing the expiration time as now + 5 minutes
            var expiresAt = DateTime.Now.AddMinutes(5);
            // Stores the data read from the API into the cache
            MemoryCache.Default.Add(new CacheItem(cacheKey, data),
                new CacheItemPolicy
                {
                    AbsoluteExpiration = expiresAt
                });
            return data;
        }
        else
        {
            Response.Headers.Add(headerName, "false");
            return data;
        }
    }
