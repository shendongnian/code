    public class MySingleton
    {
        private static Dictionary<string, MySingleton> myInstances = new Dictionary<string, MySingleton>();
    
        private MySingleton()
        {
            // construct instance
        }
    
        // note: could also implement using an indexer
        // also note: this is not thread-safe, but you could add a lock around it
        public static MySingleton GetInstance(string key)
        {
            if (!myInstances.ContainsKey(key))
            {
                myInstances.Add(key, new MySingleton());
            }
            return myInstances[key];
        }
    
        // other methods
    }
