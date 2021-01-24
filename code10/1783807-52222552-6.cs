    public class HomeController : Controller
    {
        private IMemoryCache _cache;
        public HomeController(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }
        public IActionResult CacheTryGetValueSet()
        {
           DateTime cacheEntry;
           // Look for cache key.
           if (!_cache.TryGetValue(CacheKeys.Entry, out cacheEntry))
           {
               // Key not in cache, so get data.
               cacheEntry = DateTime.Now;
               // Set cache options.
               var cacheEntryOptions = new MemoryCacheEntryOptions()
               // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(3));
               // Save data in cache.
            _cache.Set(CacheKeys.Entry, cacheEntry, cacheEntryOptions);
          }
          return View("Cache", cacheEntry);
       }
        
    }
