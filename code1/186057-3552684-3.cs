    public sealed class AutoDictionary<TKey, TVal> : Dictionary<TKey, TVal> where TVal : class, new()
    {
        public new TVal this[TKey key]
        {
            get
            {
                if (!ContainsKey(key))
                    Add(key, new TVal());
                return base[key];
            }
            set
            {
                base[key] = value;
            }
        }
    }
    private AutoDictionary<Entity, SuperSecretSpecialData> myPrivateEntityData = new ...;
