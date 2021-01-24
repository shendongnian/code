    public class Foo
    {
        public string FooString { get; }
    }
    public class FooWrapper : IHasMyStringProperty
    {
        private readonly Foo _foo;
        public FooWrapper(Foo foo)
        {
            _foo = foo;
        }
        public string GetTheString => _foo.FooString;
    }
