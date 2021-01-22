        class KeyValue<TKey, TValue>
        {
            public KeyValue()
            {
            }
        }
        class KeyValueList<TKey, TValue> : IEnumerable<TKey>
        {
            public KeyValueList()
            {
                // ...
            }
            
            // need this take advantage of so called "collection initializers"
            public void Add(TKey key, TValue value)
            {
                // here you will need to initalize the KeyValue object and add it
            }
            // need to implement IEnumerable<TKey> here!
        }
