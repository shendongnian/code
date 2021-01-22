    public class NullFoo : Foo
    {
        private NullFoo() : base("default value") { }
        private static NullFoo instance = new NullFoo();
        public static Foo Instance { get { return instance; } }
    }
