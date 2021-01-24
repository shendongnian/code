            private ConcurrentDictionary<object, long> cache = new ConcurrentDictionary<object, long>();
            public long ImmutableSum() 
            {
                return cache.GetOrAdd(immutable, (obj) => (obj as ImmutableDictionary<int, int>).Sum(kvp => (long)kvp.Value));                
            }
            public long ConcurrentSum() => concurrent.Sum(kvp => (long)kvp.Value);
