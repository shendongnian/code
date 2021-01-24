    class RestConsumerService
    {
        private readonly IMemoryCache _memoryCache;
        RestConsumerService(IMemoryCache memoryCache)
        {
             _memoryCache = memoryCache
        }
        string GetOAuthToken()
        {
            if (_memoryCache.TryGetValue<string>("MyTokenKey", out string access_token)) //You can store the T object as well.
            {
                return access_token;
            }
            //Do Api OAuth call
            //...
            OAuthRespone response = fetchAccessToken();
            _memoryCache.Set("MyTokenKey", response.Access_token, new TimeSpan(0, 0, result.Expires_in));
            return response.Access_token;
        }
    }
        
