    public class CacheStore<TKey, TCache>
    {
        private static object _lockStore = new object();
        private static CacheStore<TKey, TCache> _store;
        private static object _lockCache = new object();
        private static Dictionary<TKey, TCache> _cache =
                                                new Dictionary<TKey, TCache>();
        public TCache this[TKey index]
        {
            get
            {
                lock (_lockCache)
                {
                    if (_cache.ContainsKey(index))
                        return _cache[index];
                    return default(TCache);
                }
            }
            set
            {
                lock (_lockCache)
                {
                    if (_cache.ContainsKey(index))
                        _cache.Remove(index);
                    _cache.Add(index, value);
                }
            }
        }
        public static CacheStore<TKey, TCache> Instance
        {
            get
            {
                lock (_lockStore)
                {
                    if (_store == null)
                        _store = new CacheStore<TKey, TCache>();
                    return _store;
                }
            }
        }
    }
    public class FileCache
    {
        private WeakReference _cache;
        public FileCache(string fileLocation)
        {
            if (!File.Exists(fileLocation))
                throw new FileNotFoundException("fileLocation", fileLocation);
            this.FileLocation = fileLocation;
        }
        private MemoryStream GetStream()
        {
            if (!File.Exists(this.FileLocation))
                throw new FileNotFoundException("fileLocation", FileLocation);
            return new MemoryStream(File.ReadAllBytes(this.FileLocation));
        }
        public string FileLocation { get; private set; }
        public MemoryStream Data
        {
            get
            {
                if (_cache == null)
                    _cache = new WeakReference(GetStream(), false);
                var ret = _cache.Target as MemoryStream;
                if (ret == null)
                {
                    Recreated++;
                    ret = GetStream();
                    _cache.Target = ret;
                }
                return ret;
            }
        }
        public int Recreated { get; private set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var cache = CacheStore<string, FileCache>.Instance;
            var fileName = @"c:\boot.ini";
            cache[fileName] = new FileCache(fileName);
            var ret = cache[fileName].Data.ToArray();
            Console.WriteLine("Recreated {0}", cache[fileName].Recreated);
            Console.WriteLine(Encoding.ASCII.GetString(ret));
            GC.Collect();
            var ret2 = cache[fileName].Data.ToArray();
            Console.WriteLine("Recreated {0}", cache[fileName].Recreated);
            Console.WriteLine(Encoding.ASCII.GetString(ret2));
            GC.Collect();
            var ret3 = cache[fileName].Data.ToArray();
            Console.WriteLine("Recreated {0}", cache[fileName].Recreated);
            Console.WriteLine(Encoding.ASCII.GetString(ret3));
            Console.Read();
        }
    }
