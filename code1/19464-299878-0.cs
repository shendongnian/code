    public class DoubleLookup<TKey, TValue>
    {
      private IDictionary<TKey, TValue> keys;
      private IDictionary<TValue, TKey> values;
    
      //stuff...
    
      public void Add(TKey key, TValue value)
      {
        this.keys.Add(key, value);
        this.values.Add(value, key);
      }
    
      public TKey GetKeyFromValue(TValue value)
      {
        return this.values[value];
      }
    
      public TValue GetValueFromKey(TKey key)
      {
        return this.keys[key];
      }
    
    
    }
