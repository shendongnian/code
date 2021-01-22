    public class Foo
    {
        public Foo() { }
        public Foo(int j) { }
    }
    
    public class Bar : Foo
    {
        public Bar() : base() { }
        public Bar(int j) : base(j) { }
    }
