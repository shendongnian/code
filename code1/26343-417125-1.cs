    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class Test
    {
        static void Main()
        {
            Config config = new Config
            {
                { null,  null,  null,  1 },
                { 1,     null,  null,  2 },
                { 1,     null,  3,     3 },
                { null,  2,     3,     4 },
                { 1,     2,     3,     5 }
            };
            
            Console.WriteLine(config[1, 2, 3]);
            Console.WriteLine(config[3, 2, 3]);
            Console.WriteLine(config[9, 10, 11]);
            Console.WriteLine(config[1, 10, 11]);
        }
    }
    
    // Only implement IEnumerable to allow the collection initializer
    // Not really implemented yet - consider how you might want to implement :)
    public class Config : IEnumerable
    {
        // Aargh - death by generics :)
        private readonly DefaultingMap<int, 
                             DefaultingMap<int, DefaultingMap<int, int>>> map
            = new DefaultingMap<int, DefaultingMap<int, DefaultingMap<int, int>>>();
        
        public int this[int key1, int key2, int key3]
        {
            get
            {
                return map[key1][key2][key3];
            }
        }
        
        public void Add(int? key1, int? key2, int? key3, int value)
        {
            map.GetOrAddNew(key1).GetOrAddNew(key2)[key3] = value;
        }
        
        public IEnumerator GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }
    
    internal class DefaultingMap<TKey, TValue>
        where TKey : struct 
        where TValue : new()
    {
        private readonly Dictionary<TKey, TValue> mapped = new Dictionary<TKey, TValue>();
        private TValue unmapped = new TValue();
        
        public TValue GetOrAddNew(TKey? key)
        {
            if (key == null)
            {
                return unmapped;
            }
            TValue ret;
            if (mapped.TryGetValue(key.Value, out ret))
            {
                return ret;
            }
            ret = new TValue();
            mapped[key.Value] = ret;
            return ret;
        }
        
        public TValue this[TKey key]
        {
            get
            {
                TValue ret;
                if (mapped.TryGetValue(key, out ret))
                {
                    return ret;
                }
                return unmapped;
            }
        }
        
        public TValue this[TKey? key]
        {
            set
            {
                if (key != null)
                {
                    mapped[key.Value] = value;
                }
                else
                {
                    unmapped = value;
                }
            }
        }
    }
