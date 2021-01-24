    public abstract class BaseCache
    {
      private readonly object cacheLock = new object();
      protected ObjectCache cache = MemoryCache.Default;
    
      public List<string> Get()
      {
            // for example. It could be anywhere and return any type.
            ChildLogic();
            var data = cache.Get(key);
    
            if (data != null)
                return;
    
            lock (cacheLock)
            {
                // Check again.
                data = cache.Get(key);
    
                if (data != null)
                    return;
    
                // Populate, and return.
                PopulateFromElsewhere();
            }
      }
    
      protected abstract void ChildLogic();
      protected abstract void PopulateFromElsewhere();
    }
