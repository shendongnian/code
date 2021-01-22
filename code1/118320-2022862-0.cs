    using System.Collections;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            var dictionary = new HybridDictionary<string, string>
                                     {
                                         {"key", "value"}, 
                                         {"key2", "value2"}
                                     };
        }
    }
    
    public class HybridDictionary<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        private readonly Dictionary<TKey, TValue> inner = new Dictionary<TKey, TValue>();
        public void Add(TKey key, TValue value)
        {
            inner.Add(key, value);
        }
    
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return inner.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
