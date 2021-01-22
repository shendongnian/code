    {
        cache.Add("key", "value", CacheItemPriority.Normal, 
                  null, new SlidingTime(TimeSpan.FromSeconds(5)));
        System.Threading.Thread.Sleep(6000);
        Console.WriteLine(cache.Contains("key"));        /// true
        Console.WriteLine(cache.GetData("key") != null); /// false
        Console.WriteLine(cache.Contains("key"));        /// false
    }
