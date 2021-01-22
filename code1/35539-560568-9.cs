    // option 5
    class Foo
    {
        public int PublicProperty { get; private set; }
        public LazyEval<int> LazyProperty { get; private set; }
        public Foo()
        {
            LazyProperty = () => this.PublicProperty;
        }
        public void DoStuff()
        {
            var lazy = LazyProperty; // type is inferred as LazyEval`1, no eval
            PublicProperty = 7;
            int i = lazy; // same as lazy.Eval()
            Console.WriteLine(i); // WriteLine(7)
        }
    }
