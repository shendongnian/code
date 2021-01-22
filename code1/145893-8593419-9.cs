       public class PairList<TKey, TValue> : List<KeyValuePair<TKey, TValue>> {
            Dictionary<TKey, int> itsIndex = new Dictionary<TKey, int>();
    
            public void Add(TKey key, TValue value) {
                Add(new KeyValuePair<TKey, TValue>(key, value));
                itsIndex.Add(key, Count-1);
            }
    
            public TValue Get(TKey key) {
                var idx = itsIndex[key];
                return this[idx].Value;
            }
        }
