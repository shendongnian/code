    class SomeType
    {
        public Int32 Value;
    }
    SomeType x = new SomeType;
    x.Value = 10;
    SomeType y = x; // reference type, so y now refers to the same object x refers to
    y.Value = 20; // now x.Value is also 20, since x and y refer to the same object
