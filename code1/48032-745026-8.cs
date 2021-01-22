    public class Cache<Tkey, Tvalue> {
        enum Stale { Refresh, Created }
    
        /* Caches data received from a delegate
         *
         * The difference between this method and usual Cache.get
         * is following: this method caches data and allows user
         * to re-generate data when it is expired w/o running
         * data generation code more than once so dog-pile effect
         * won't bring our servers down
        */
        public static Tvalue SmartGet(Tkey key, TimeSpan ttl, TimeSpan generationTime, Func<Tvalue> strategy)
        {
            // Create window for data refresh
            var realTtl = ttl + generationTime * 2;
            var staleKey = String.Format("{0}stale", key);
    
            // Try to get data from memcache
            var value = Get(key);
            var stale = Get(staleKey);
    
            // If stale key has expired, it is time to re-generate our data
            if (stale == null)
            {
                Put(staleKey, Stale.Refresh, generationTime); // lock
                value = null; // force data re-generation
            }
    
            // If no data retrieved or data re-generation forced, re-generate data and reset stale key
            if (value == null)
            {
                value = strategy();
                Put(key, value, realTtl);
                Put(staleKey, Stale.Created, ttl) // unlock
            }
    
            return value;
        }
    
        // Fallback to default caching approach if no ttl given
        public static Tvalue SmartGet(Tkey key, Func<Tvalue> strategy)
        {
            return Get(key, strategy);
        }
    
        // Simulate default argument for generationTime
        // C# 4.0 has default arguments, so this wouldn't be needed.
        public static Tvalue SmartGet(Tkey key, TimeSpan ttl, Func<Tvalue> strategy)
        {
            return SmartGet(key, ttl, new TimeSpan(0, 0, 30), strategy);
        }
    
        // Convenience overloads to allow calling it the same way as 
        // in Ruby, by just passing in the timespans as integers in 
        // seconds.
        public static Tvalue SmartGet(Tkey key, int ttl, int generationTime, Func<Tvalue> strategy)
        {
            return SmartGet(key, new TimeSpan(0, 0, ttl), new TimeSpan(0, 0, generationTime), strategy);
        }
    
        public static Tvalue SmartGet(Tkey key, int ttl, Func<Tvalue> strategy)
        {
            return SmartGet(key, new TimeSpan(0, 0, ttl), strategy);
        }
    }
