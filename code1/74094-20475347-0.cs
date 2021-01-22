      public class TwoKeyDictionary<TKey1, TKey2, TValue> : Dictionary<TwoKey<TKey1, TKey2>, TValue>
      {
        public static TwoKey<TKey1, TKey2> Key(TKey1 key1, TKey2 key2)
        {
          return new TwoKey<TKey1, TKey2>(key1, key2);
        }
    
        public TValue this[TKey1 key1, TKey2 key2]
        {
          get { return this[Key(key1, key2)]; }
          set { this[Key(key1, key2)] = value; }
        }
    
        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
          Add(Key(key1, key2), value);
        }
    
        public bool ContainsKey(TKey1 key1, TKey2 key2)
        {
          return ContainsKey(Key(key1, key2));
        }
      }
    
      public class TwoKey<TKey1, TKey2> : Tuple<TKey1, TKey2>
      {
        public TwoKey(TKey1 item1, TKey2 item2) : base(item1, item2) { }
    
        public override string ToString()
        {
          return string.Format("({0},{1})", Item1, Item2);
        }
      }
