        internal class DictionaryEntry<TKey, TValue>
        {
            public Dictionary<TKey, DictionaryEntry<TKey, TValue>> Children { get; private set; }
            public TValue Value { get; private set; }
            public bool HasValue { get; private set; }
                
            public void SetValue(TValue value)
            {
                Value = value;
                HasValue = true;
            }
        
            public DictionaryEntry()
            {
                Children = new Dictionary<TKey, DictionaryEntry<TKey, TValue>>();
            }
        }
    
        internal class KeyStackDictionary<TKey,TValue>
        {
        // Helper dictionary to work with a stack of keys
        // Usage:
        // var dict = new KeyStackDictionary<int, string>();
        // int[] keyStack = new int[] {23, 43, 54};
        // dict.SetValue(keyStack, "foo");
        // string value;
        // if (dict.GetValue(keyStack, out value))
        // {   
        // }
    
        private DictionaryEntry<TKey, TValue> _dict;
    
        public KeyStackDictionary()
        {
            _dict = new DictionaryEntry<TKey, TValue>();
        }
    
        public void SetValue(TKey[] keyStack, TValue value)
        {
            DictionaryEntry<TKey, TValue> dict = _dict;
    
            for (int i = 0; i < keyStack.Length; i++)
            {
                TKey key = keyStack[i];
                if (dict.Children.ContainsKey(key))
                {
                    dict = dict.Children[key];
                }
                else
                {
                    var child = new DictionaryEntry<TKey, TValue>();
                    dict.Children.Add(key, child);
                    dict = child;
                }
    
                if (i == keyStack.Length - 1)
                {
                    dict.SetValue(value);
                }
            }
        }
    
        // returns false if the value is not found using the key stack
        public bool GetValue(TKey[] keyStack, out TValue value)
        {
            DictionaryEntry<TKey, TValue> dict = _dict;
                
            for (int i = 0; i < keyStack.Length; i++)
            {
                TKey key = keyStack[i];
    
                if (dict.Children.ContainsKey(key))
                {
                    dict = dict.Children[key];
                }
    
                if (i == keyStack.Length - 1 && dict.HasValue)
                {
                    value = dict.Value;
                    return true;
                }
            }
    
            value = default(TValue);
            return false;
        }
    }
