    // option 5
    class Foo
    {
        public LazyEval<MyClass> LazyProperty { get; private set; }
        public Foo()
        {
            LazyProperty = () => new MyClass();
        }
    }
