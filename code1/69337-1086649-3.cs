    static class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Foo.abc.IsSet(Foo.abc));
            Debug.Assert(Bar.abc.IsSet(Bar.abc));
            Debug.Assert(Baz.abc.IsSet(Baz.abc));
        }
        enum Foo : int
        {
            abc = 1,
            def = 10,
            ghi = 100
        }
        enum Bar : sbyte
        {
            abc = 1,
            def = 10,
            ghi = 100
        }
        enum Baz : ulong
        {
            abc = 1,
            def = 10,
            ghi = 100
        }
    }
