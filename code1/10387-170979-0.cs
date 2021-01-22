    internal static class Foo
    {
        internal static readonly EventHandler EmptyEvent = delegate { };
    }
    public class Bar
    {
        public event EventHandler SomeEvent = Foo.EmptyEvent;
    }
