    class Foo
    {
        public SomeObject MyObject { get; private set; }
        public Foo()
        {
            MyObject = new SomeObject();
        }
    }
