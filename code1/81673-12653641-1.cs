    private static void CachingBlockTest()
    {
        while (true)
        {
            System.Threading.Thread.Sleep(2000);
    
            var key = new Random().Next(3).ToString();
            string value = cache.GetData(key) as string;
    
            if (value == null)
            {
                value = key;
                cache.Add(key, value, CacheItemPriority.Normal, new RefreshAction(),
                    new SlidingTime(TimeSpan.FromSeconds(5)));
            }
            Console.WriteLine("{0} --> '{1}'", key, value);
        } 
    }
    private class RefreshAction : ICacheItemRefreshAction
    {
        public void Refresh(string removedKey, object expiredValue, CacheItemRemovedReason removalReason)
        {
            Console.WriteLine("{0} --> {1} removed", removedKey, expiredValue);
        }
    }
