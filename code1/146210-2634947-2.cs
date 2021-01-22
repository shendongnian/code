    class Foo 
    {
        public int Bar { get; set; }
    }
    static class FooExtensions 
    {
        public static Foo AddBar(this Foo foo, int b)
        {
            foo.Bar += b;
            return foo;
        }
    }
