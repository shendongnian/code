    public class DictionaryWithDefault<TKey, TValue> : Dictionary<TKey, TValue>
    {
      TValue _default;
      public TValue DefaultValue {
        get { return _default; }
        set { _default = value; }
      }
      public DictionaryWithDefault() : base() { }
      public DictionaryWithDefault(TValue defaultValue) : base() {
        _default = defaultValue;
      }
      public new TValue this[TKey key]
      {
        get { return base.ContainsKey(key) ? base[key] : _default; }
        set { base[key] = value; }
      }
    }
