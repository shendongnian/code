    public static ICacheManager cache = CacheFactory.GetCacheManager("Cache Manager"); 
    
    static void Main(string[] args)
    {
        CachingBlockTest();
        Console.WriteLine("Done");
        Console.ReadLine();
    }
    
    private static void CachingBlockTest()
    {
        ThreadLocal<Random> localRandom = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));
        object locker = new object();
        ConcurrentQueue<string> resultQueue = new ConcurrentQueue<string>();
    
        Parallel.For(0, 10, i =>
        {
            for (int x = 0; x < 25; x++)
            {
                string key = localRandom.Value.Next(1, 5).ToString();
                string value = cache.GetData(key) as string;
                if (value == null)
                {
                    lock (locker)
                    {
                        value = cache.GetData(key) as string;
                        if (value == null)
                        {
                            cache.Add(key, key, CacheItemPriority.Normal, null, new SlidingTime(TimeSpan.FromSeconds(5)));
                            value = key;
                        }
                    }
                        
                }
                // this causes thread contention and should not be used in multithreaded scenerios.
                //Console.WriteLine("Thread {0}: {1} --> '{2}'", i, key, value);
                resultQueue.Enqueue(string.Format("Thread {0}: {1} --> '{2}'", i, key, value));
                Thread.Sleep(1000);
            }
        });
    
        // dump the results
        foreach (string s in resultQueue)
        {
            Console.WriteLine(s);
        }
    }
