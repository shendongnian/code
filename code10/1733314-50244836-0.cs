    public class TwoKeyDictionary<TKey1, TKey2, TValue>
    {
        private List<TKey1> firstKeys  = new List<TKey1>();
        private List<TKey2> secondKeys = new List<TKey2>();
        private List<TValue> values    = new List<TValue>();
        public void Add(TKey1 key1, TKey2 key2, TValue value)
        {
            if (firstKeys.Contains(key1))  throw new ArgumentException();
            if (secondKeys.Contains(key2)) throw new ArgumentException();
            firstKeys.Add(key1);
            secondKeys.Add(key2);
            values.Add(value);
        }
        public TValue this[TKey1 key1]
        {
            get
            {
                int index = firstKeys.IndexOf(key1);
                if (index < 0) throw new IndexOutOfRangeException();
                return values[firstKeys.IndexOf(key1)];
            }
        }
        public TValue this[TKey2 key2]
        {
            get
            {
                int index = secondKeys.IndexOf(key2);
                if (index < 0) throw new IndexOutOfRangeException();
                return values[secondKeys.IndexOf(key2)];
            }
        }
    }
