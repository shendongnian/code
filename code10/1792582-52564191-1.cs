    public static async Task<List<string>> GetDomainsAsync(IMemoryCache _cache)
    {
        return await ContextCache.CacheTryGetValueSet<string>("SP_GET_DOMAINS", _cache).ToList();
    }
    public static async Task<Dictionary<String, String>> GetSettingsAsync(IMemoryCache _cache)
    {
        return await ContextCache.CacheTryGetValueSet<String, String>("SP_GET_SETTINGS", _cache).ToDictionary();
    }
