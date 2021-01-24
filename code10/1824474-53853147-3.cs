    private CacheInvalidationRequestModel GetCacheInvalidationRequestModel(string absolutePath)
    {
        return new CacheInvalidationRequestModel()
        {
            Region = Options.Region,
            Host = Options.Host,
            AccessKey = Options.InvalidatorKey,
            SecretKey = Options.InvalidatorSecret,
            AbsolutePath = absolutePath
        };
    }
