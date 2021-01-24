    private async Task<IActionResult> GetCache<T>(Func<T> createAction, [CallerMemberName] string actionName = null)
    {
        var cacheKey = GetType().Name + "_" + actionName;
        var result = await MemoryCache.GetOrCreateAsync(cacheKey, entry => createAction());
        return Json(result);
    }
