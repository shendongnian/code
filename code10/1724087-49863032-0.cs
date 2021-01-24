    public async Task<IEnumerable<Ticket>> GetTicket(int id)
    {
        var localId = id;
        return await _memoryCache.GetOrCreateAsync(_cachingFunctionalty.BuildCachingName(localId), entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromSeconds(10);
            return GetTicket_uncached(localId);
        });
    }
