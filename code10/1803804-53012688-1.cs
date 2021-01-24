    public struct MyBigStruct
    {
        public Decimal Foo;
        public Decimal Bar;
        public Decimal Baz;
    }
    public static void Main()
    {
        MyBigStruct value; // 48 bytes
        Foo( in value ); // Get an 8-byte pointer to `value`, then pass that
    }
    public static void Foo( in MyBigStruct x ) { ... }
