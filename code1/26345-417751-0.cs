    ------------ Test.cs -----------------
    using System;
    
    sealed class Test
    {
        static void Main()
        {
            Config config = new Config(10, 7, 5)
            {
                { null, null, null, 1 },
                {null,  null,  null,  1},
                {1,     null,  null,  2},
                {9,     null,  null,  21},
                {1,     null,  3,     3 },
                {null,  2,     3,     4 },
                {1,     2,     3,     5 }
            };
            
            Console.WriteLine(config[1, 2, 3]);
            Console.WriteLine(config[3, 2, 3]);
            Console.WriteLine(config[8, 10, 11]);
            Console.WriteLine(config[1, 10, 11]);
            Console.WriteLine(config[9, 2, 3]);
            Console.WriteLine(config[9, 3, 3]);
        }
    }
    
    --------------- Config.cs -------------------
    using System;
    using System.Collections;
    
    sealed class Config : IEnumerable
    {
        private readonly PartialMatchDictionary<int, int> dictionary;
    
        public Config(int priority1, int priority2, int priority3)
        {
            dictionary = new PartialMatchDictionary<int, int>(priority1, priority2, priority3);
        }
    
        public void Add(int? key1, int? key2, int? key3, int value)
        {
            dictionary[new[] { key1, key2, key3 }] = value;
        }
    
        public int this[int key1, int key2, int key3]
        {
            get
            {
                return dictionary[new[] { key1, key2, key3 }];
            }
        }
    
        // Just a fake implementation to allow the collection initializer
        public IEnumerator GetEnumerator()
        {
            throw new NotSupportedException();
        }
    }
    
    -------------- PartialMatchDictionary.cs -------------------
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public sealed class PartialMatchDictionary<TKey, TValue> where TKey : struct
    {
        private readonly List<Dictionary<TKey[], TValue>> dictionaries;
        private readonly int keyComponentCount;
    
        public PartialMatchDictionary(params int[] priorities)
        {
            keyComponentCount = priorities.Length;
            dictionaries = new List<Dictionary<TKey[], TValue>>(1 << keyComponentCount);
            for (int i = 0; i < 1 << keyComponentCount; i++)
            {
                PartialComparer comparer = new PartialComparer(keyComponentCount, i);
                dictionaries.Add(new Dictionary<TKey[], TValue>(comparer));
            }
            dictionaries = dictionaries.OrderByDescending(dict => ((PartialComparer)dict.Comparer).Score(priorities))
                                       .ToList();
        }
    
        public TValue this[TKey[] key]
        {
            get
            {
                if (key.Length != keyComponentCount)
                {
                    throw new ArgumentException("Invalid key component count");
                }
                foreach (Dictionary<TKey[], TValue> dictionary in dictionaries)
                {
                    TValue value;
                    if (dictionary.TryGetValue(key, out value))
                    {
                        return value;
                    }
                }
                throw new KeyNotFoundException("No match for this key");
            }
        }
    
        public TValue this[TKey?[] key]
        {
            set
            {
                if (key.Length != keyComponentCount)
                {
                    throw new ArgumentException("Invalid key component count");
                }
                // This could be optimised (a dictionary of dictionaries), but there
                // won't be many additions to the dictionary compared with accesses
                foreach (Dictionary<TKey[], TValue> dictionary in dictionaries)
                {
                    PartialComparer comparer = (PartialComparer)dictionary.Comparer;
                    if (comparer.IsValidForPartialKey(key))
                    {
                        TKey[] maskedKey = key.Select(x => x ?? default(TKey)).ToArray();
                        dictionary[maskedKey] = value;
                        return;
                    }
                }
                throw new InvalidOperationException("We should never get here");
            }
        }
    
        private sealed class PartialComparer : IEqualityComparer<TKey[]>
        {
            private readonly int keyComponentCount;
            private readonly bool[] usedKeyComponents;
            private static readonly EqualityComparer<TKey> Comparer = EqualityComparer<TKey>.Default;
    
            internal PartialComparer(int keyComponentCount, int usedComponentBits)
            {
                this.keyComponentCount = keyComponentCount;
                usedKeyComponents = new bool[keyComponentCount];
                for (int i = 0; i < keyComponentCount; i++)
                {
                    usedKeyComponents[i] = ((usedComponentBits & (1 << i)) != 0);
                }
            }
    
            internal int Score(int[] priorities)
            {
                return priorities.Where((value, index) => usedKeyComponents[index]).Sum();
            }
    
            internal bool IsValidForPartialKey(TKey?[] key)
            {
                for (int i = 0; i < keyComponentCount; i++)
                {
                    if ((key[i] != null) != usedKeyComponents[i])
                    {
                        return false;
                    }
                }
                return true;
            }
    
            public bool Equals(TKey[] x, TKey[] y)
            {
                for (int i = 0; i < keyComponentCount; i++)
                {
                    if (!usedKeyComponents[i])
                    {
                        continue;
                    }
                    if (!Comparer.Equals(x[i], y[i]))
                    {
                        return false;
                    }
                }
                return true;
            }
    
            public int GetHashCode(TKey[] obj)
            {
                int hash = 23;
                for (int i = 0; i < keyComponentCount; i++)
                {
                    if (!usedKeyComponents[i])
                    {
                        continue;
                    }
                    hash = hash * 37 + Comparer.GetHashCode(obj[i]);
                }
                return hash;
            }
        }
    }
