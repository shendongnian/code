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
    
    public class CacheObject<T>
    {
        private static CacheObject<T> _instance = new CacheObject<T>();
        public static CacheObject<T> Instance { get { return _instance; } }
    
        private Dictionary<string, T> _store = new Dictionary<string, T>();
        public T this[string index]
        {
            get { return _store.ContainsKey(index) ? _store[index] : default(T); }
            set
            {
                if (_store.ContainsKey(index)) _store.Remove(index);
                if (value != null) _store.Add(index, value);
            }
        }
    }
