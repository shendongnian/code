    public abstract class FooComparer
    {
        private readonly FooComparer _next;
        public FooComparer(FooComparer next)
        {
            _next = next;
        }
        public bool CompareFoo(Foo a, Foo b)
        {
            return AreFoosEqual(a, b) 
                && (_next?.CompareFoo(a, b) ?? true);
        }
        protected abstract bool AreFoosEqual(Foo a, Foo b);
    }
    public class FooNameComparer : FooComparer
    {
        public FooNameComparer(FooComparer next) : base(next)
        {
        }
        protected override bool AreFoosEqual(Foo a, Foo b)
        {
            return a.Name == b.Name;
        }
    }
    public class FooBarComparer : FooComparer
    {
        public FooBarComparer(FooComparer next) : base(next)
        {
        }
        protected override bool AreFoosEqual(Foo a, Foo b)
        {
            return a.Bar == b.Bar;
        }
    }
