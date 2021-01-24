<!-- -->
    
    public class Program
    {
    	
    	public static void Main()
    	{
    		Device dev = new Device();
    		
    		Cache cache = new Cache();
    		cache.CacheStrategy = CacheFactory.NoCacheStrategy(cache);
    		
    		for (int i = 0; i < 10; ++i)
    		{
    			Console.Write(cache.Get(dev.Get) + " ");
    		}
    		Console.WriteLine();
    		
    		
    		cache.CacheStrategy = CacheFactory.ForeverCacheStrategy(cache);
    		
    		for (int i = 0; i < 10; ++i)
    		{
    			Console.Write(cache.Get(dev.Get) + " ");
    		}
    		Console.WriteLine();
    		
    		
    		cache.CacheStrategy
                = CacheFactory.SimpleCacheStrategy(cache, TimeSpan.FromMilliseconds(300));
    		
    		for (int i = 0; i < 10; ++i)
    		{
    			Console.Write(cache.Get(dev.Get) + " ");
    			System.Threading.Thread.Sleep(TimeSpan.FromMilliseconds(100));
    		}
    		Console.WriteLine();
    
    	}
    }
