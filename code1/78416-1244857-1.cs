    class Program
    {
        static void Main(string[] args)
        {
            CacheObject<int>.Instance["hello"] = 5;
            CacheObject<int>.Instance["hello2"] = 6;
            CacheObject<string>.Instance["hello2"] = "hi";
            Console.WriteLine(CacheObject<string>.Instance["hello2"]); //returns hi
        }
    }
    
    public class CacheObject<V> : CacheObject<string, V> { }
    public class CacheObject<K,V>
    {
        private static CacheObject<K, V> _instance = new CacheObject<K, V>();
        public static CacheObject<K, V> Instance { get { return _instance; } }
    
        private Dictionary<K, V> _store = new Dictionary<K, V>();
        public T this[K index]
        {
            get { return _store.ContainsKey(index) ? _store[index] : default(V); }
            set
            {
                if (_store.ContainsKey(index)) _store.Remove(index);
                if (value != null) _store.Add(index, value);
            }
        }
    }
