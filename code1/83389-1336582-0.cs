    public class ReadWriteDictionary<K,V>
    {
        private readonly Dictionary<K,V> dict = new Dictionary<K,V>();
        private readonly ReaderWriterLockSlim rwLock = new ReaderWriterLockSlim();
        public V Get(K key)
        {
            return ReadLock(() => dict[key]);
        }
        public void Set(K key, V value)
        {
            WriteLock(() => dict.Add(key, value));
        }
        public IEnumerable<KeyValuePair<K, V>> GetPairs()
        {
            return ReadLock(() => dict.ToList());
        }
        private V2 ReadLock<V2>(Func<V2> func)
        {
            rwLock.EnterReadLock();
            try
            {
                return func();
            }
            finally
            {
                rwLock.ExitReadLock();
            }
        }
        private void WriteLock(Action action)
        {
            rwLock.EnterWriteLock();
            try
            {
                action();
            }
            finally
            {
                rwLock.ExitWriteLock();
            }
        }
    }
    Cache["somekey"] = new ReadWriteDictionary<string,int>();
