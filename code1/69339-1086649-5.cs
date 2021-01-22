    static class Program
    {
        static void Main(string[] args)
        {
            Debug.Assert(Foo.abc.IsSet(Foo.abc));
            Debug.Assert(Bar.def.IsSet(Bar.def));
            Debug.Assert(Baz.ghi.IsSet(Baz.ghi));
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
