     [Serializable]
     public class SerializableKeyValuePair<TKey, TValue>
        {
    
            public SerializableKeyValuePair()
            {
            }
    
            public SerializableKeyValuePair(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
    
            public TKey Key { get; set; }
            public TValue Value { get; set; }
            
        }
