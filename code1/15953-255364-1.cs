    public class MyDict &lt TKey, TValue &gt : Dictionary &lt TKey, TValue &gt
    {
        private Dictionary &lt TValue, TKey &gt _keys;
        public TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set 
            { 
                base[key] = value;
                _keys[value] = key;
            }
        }
        public MyDict()
        {
            _keys = new Dictionary &lt TValue, TKey &gt();
        }
        public TKey GetKeyFromValue(TValue value)
        {
            return _keys[value];
        }
    }
