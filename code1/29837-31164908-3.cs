    struct SomeValueType2 : IComparable
    {
        private int _v;
        public SomeValueType2(int v)
        {
            _v = v;
        }
        public int CompareTo(SomeValueType2 svt2)
        {
            return _v - svt2._v;
        }
        int IComparable.CompareTo(object obj)
        {
            return CompareTo((SomeValueType2)obj);
        }
    }
