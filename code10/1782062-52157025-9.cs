<!-- -->
    
    public class Program
    {
        public static void Main()
        {
            Device dev = new Device();
            Cache cache = new Cache();
    
    		cache.ResetCache();
            cache.CacheStrategy = CacheFactory.NoCacheStrategy(cache);
    		Console.Write("no cache strategy:            ");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(cache.Get(dev.Get) + " ");
            }
            Console.WriteLine();
    
    		cache.ResetCache();
            cache.CacheStrategy = CacheFactory.ForeverCacheStrategy(cache);
    		Console.Write("forever cache strategy:       ");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(cache.Get(dev.Get) + " ");
            }
            Console.WriteLine();
    
    		cache.ResetCache();
            cache.CacheStrategy
                = CacheFactory.SimpleCacheStrategy(cache, TimeSpan.FromMilliseconds(300));
    		Console.Write("refresh after 300ms strategy: ");
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(cache.Get(dev.Get) + " ");
                System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(100));
            }
            Console.WriteLine();
        }
    }
