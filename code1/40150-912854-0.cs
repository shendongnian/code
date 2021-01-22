    // Add HttpCaching data to the http headers
    if (!IsJavascriptDebug && (
        AssemblyModifiedDate.ToUniversalTime() < DateTime.UtcNow))
    {
        HttpCachePolicy cache = context.Response.Cache;
        cache.SetCacheability(HttpCacheability.Public);
        cache.SetLastModified(AssemblyModifiedDate);
    }
