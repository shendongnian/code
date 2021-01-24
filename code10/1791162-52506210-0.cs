    private async Task<IActionResult> GetCache<T>(string cacheKey, Func<T> createAction)
    {
        var result = await MemoryCache.GetOrCreateAsync(cacheKey, entry => createAction());
        return Json(result);
    }
