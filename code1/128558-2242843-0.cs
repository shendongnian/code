    protected class Bar : IComparable, IComparable<Bar>
    {
        private KeyValuePair<T, string> _keyval;
        public Bar(KeyValuePair<T, string> kv)
        {
            _keyval = kv;
        }
        public int CompareTo(Bar other)
        {
            return _keyval.Key.CompareTo(other._keyval.Key);
        }
        int IComparable.CompareTo(object obj)
        {
            return CompareTo(obj as Bar);
        }
    }
