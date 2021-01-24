    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        public MyDictionary(IDictionary<TKey, TValue> realDictionary)
        {
             _dictionary = realDictionary;
        }
        ...
        public TValue this[TKey key]
        {
            get
            {
                try
                {
                    return _dictionary[key];
                }
                catch (KeyNotFoundException e)
                {
                    throw new KeyNotFoundException($"Key {key} is not in the dictionary", e);
                }
            }
            ...
        }
        ...
    }
