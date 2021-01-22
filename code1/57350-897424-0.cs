    public class TigerCacheableService implements CacheableService {
    
      @Cacheable(modelId = "testCaching")
      public final String getName(int index) {
        // some implementation.
      }
    ...
    }
