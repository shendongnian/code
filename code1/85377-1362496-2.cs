        class KeyValue<TKey, TValue>
        {
            public KeyValue()
            {
            }
        }
        
        // 1. change: need to implement IEnumerable interface
        class KeyValueList<TKey, TValue> : IEnumerable<TKey>
        {
            // 2. prerequisite: parameterless constructor needed
            public KeyValueList()
            {
                // ...
            }
            
            // 3. need Add method to take advantage of
            // so called "collection initializers"
            public void Add(TKey key, TValue value)
            {
                // here you will need to initalize the
                // KeyValue object and add it
            }
            // need to implement IEnumerable<TKey> here!
        }
