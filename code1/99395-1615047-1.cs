    class SomeType
    {
        public Int32 Value;
    }
    SomeType x = new SomeType;
    x.Value = 10;
    SomeType y = x; // value types, so distinct from x
    y.Value = 20; // now x.Value is also 20, since x and y refers to the same object
