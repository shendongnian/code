    struct SomeType
    {
        public Int32 Value;
    }
    SomeType x = new SomeType;
    x.Value = 10;
    SomeType y = x; // value types, so distinct from x
    y.Value = 20; // x.Value is still 10
