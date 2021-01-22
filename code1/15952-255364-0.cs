    public class MyDictionary &lt TKey, TValue &gt : Dictionary &lt TKey, TValue &gt
    {
        private Dictionary &lt TValue, TKey &gt _keys = new Dictionary &lt TValue, TKey &gt ();
        public TKey GetKeyFromValue(TValue value)
        {
            return _keys[value];
        }
    }
