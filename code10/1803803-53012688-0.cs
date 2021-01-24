    public static void Main()
    {
        Int32 value = 123; // 4 bytes
        Foo( in value ); // Get an 8-byte pointer to `value`, then pass that
    }
    public static void Foo( in Int32 x ) { ... }
