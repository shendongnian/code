    public class LastDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> dict;
        public LastDictionary()
        {
            dict = new Dictionary<TKey, TValue>();
        }
        public void Add(TKey key, TValue value)
        {
            LastKey = key;
            LastValue = value;
            dict.Add(key, value);
        }
        public TKey LastKey
        {
            get; private set;
        }
        public TValue LastValue
        {
            get; private set;
        }
    }
