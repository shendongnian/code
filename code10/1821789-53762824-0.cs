    public sealed class Foo : IInitializable
    {
        public void Initialize()
        {
            // Initialize my foo
        }
        private Foo()
        {
        }
        private static Lazy<Foo> fooLazy = new Lazy<Foo>(() => new Foo());
        public static Foo Instance => fooLazy.Value;
    }
