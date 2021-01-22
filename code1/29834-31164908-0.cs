    struct SomeValueType1 : IComparable
    {
        private int _v;
        public SomeValueType1(int v)
        {
            _v = v;
        }
        public int CompareTo(object obj)
        {
            return _v - ((SomeValueType1)obj)._v;
        }
    }
