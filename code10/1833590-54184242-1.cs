    class ClassThatNeedsACache
    {
        ICache _cache;
        ClassThatNeedsACache(ICache cache)
        {
            _cache = cache;
        }
        void MethodThatUsesACache()
        {
            // Some other code to create your encodedCurrentTimeUTC and expiration
            _cache.Add("time", encodedCurrentTimeUTC, expiration);
        }
    }
