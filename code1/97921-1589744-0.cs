    public class StickyDictionary<Key, Value> : IEnumerable<KeyValuePair<Key, Value>>{
    
       private Dictionary<Key, Value> _colleciton;
    
       public StickyDictionary() {
          _collection = new Dictionary<Key, Value>();
       }
    
       public void Add(Key key, Value value) {
          _collection.Add(key, value);
       }
    
       public Value this[Key key] {
          get {
             return _collection[key];
          }
       }
    
       public IEnumerable<KeyValuePair<Key, Value>> GetEnumerator() {
          return _collection.GetEnumerator();
       }
    
    }
