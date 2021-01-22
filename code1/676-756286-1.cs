    public MyDictionary<K, T> : IDictionary<K, T>
    {
        private IDictionary<K, T> _InnerDictionary;
        
        public K LastInsertedKey { get; set; }
    
        public MyDictionary()
        {
            _InnerDictionary = new Dictionary<K, T>();
        }
    
        #region Implementation of IDictionary
        
        public void Add(KeyValuePair<K, T> item)
        {
            _InnerDictionary.Add(item);
            LastInsertedKey = item.Key;
                
        }
    
        public void Add(K key, T value)
        {
            _InnerDictionary.Add(key, value);
            LastInsertedKey = key;
        }
    
        .... rest of IDictionary methods
    
        #endregion
    
    }
