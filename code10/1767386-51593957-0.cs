    class SerialisableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            SerializeToJson();
        }
    }
