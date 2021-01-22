    public class IndexedDictionary<TKey, TValue> : IEnumerable<TValue> {
      private List<TValue> list = new List<TValue>();
      private Dictionary<TKey, TValue> dict = new Dictionary<TKey, TValue>();
    
      public TValue this[int index] { get { return list[index]; } }
      public TValue this[TKey key] { get { return dict[key]; } }
      public Dictionary<TKey, TValue>.KeyCollection Keys { get { return dict.Keys; } }
    
      public int Count { get { return list.Count; } }
      public int IndexOf(TValue item) { return list.IndexOf(item);  }
      public int IndexOfKey(TKey key) { return list.IndexOf(dict[key]); } 
    
      public void Add(TKey key, TValue value) {
        list.Add(value);
        dict.Add(key, value);
      }
    
      IEnumerator<TValue> IEnumerable<TValue>.GetEnumerator() {
        return list.GetEnumerator();
      }
    
      IEnumerator IEnumerable.GetEnumerator() {
        return list.GetEnumerator();
      }
    }
