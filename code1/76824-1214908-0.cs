    public struct BetweenNegativeFiveAndFive
    {
        public static readonly int MinValue;
        public static readonly int MaxValue;
        int _value;
        public int Value
        {
            get { return _value; }
        }
        public int Add(int a)
        {
            int b = _value + a;
            if (b >= MinValue && b <= MaxValue)
                _value = b;
            return _value;
        }
        static Foo()
        {
            MinValue = -5;
            MaxValue = 5;
        }
    }
