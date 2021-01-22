    public class MultiDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        public void Add(TKey key, TValue value)
        {
            if (TryGetValue(key, out List<TValue> valueList)) {
                valueList.Add(value);
            } else {
                Add(key, new List<TValue> { value });
            }
        }
    }
