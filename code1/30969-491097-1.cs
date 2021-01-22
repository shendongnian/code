    public static class ThreadSafeDictionary
    {
        private static readonly Dictionary<string, int> dict = new Dictionary<string, int>();
    
        public static void AddItem(string key, int value)
        {
            lock (((IDictionary)dict).SyncRoot)
            {
                if (!dict.ContainsKey(key))
                    dict.Add(key, value);
            }
        }
    }
