    public class CountableItem<T>
    {
        private class IntegerHolder
        {
            public int i;
            public IntegerHolder() { i = 1; }
        }
        Dictionary<T, IntegerHolder> dict = new Dictionary<T, IntegerHolder>();
        public void Add(T key)
        {
            IntegerHolder val = dict[key];
            if (val != null)
                val.i++;
            else
                dict.Add(key, new IntegerHolder());
        }
        public void Clear()
        {
            dict.Clear();
        }
        public int Count(T key)
        {
            IntegerHolder val = dict[key];
            if (val != null)
                return val.i;
            return 0;
        }
        // TODO - write the IEnumerable accessor.
    }
