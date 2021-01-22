    public static void AddToCache<T>(T model, double millisecs, string cacheId, Func<T> getValueFunction ) where T : class
    {
      // if miss:
      var person = getValueFunction.Invoke();
    }
