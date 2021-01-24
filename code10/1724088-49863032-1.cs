    public async Task<IEnumerable<Ticket>> GetTicket(int id)
    {
        
        return await _memoryCache.GetOrCreateAsync(_cachingFunctionalty.BuildCachingName(id), entry =>
        {
            var localId = id;
            entry.SlidingExpiration = TimeSpan.FromSeconds(10);
            return GetTicket_uncached(localId);
        });
    }
