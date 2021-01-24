    public abstract class OtherExample<TKey, TValue> : ScriptableObject
    {
        // Note that this is just an example
        // Dictionary is not serializable
        public Dictionary<TKey, TValue> values = new Dictionary<TKey, TValue>();
        public void AddPair(TKey key, TVakue value)
        {
            values.Add(key, value);
        }
    }
