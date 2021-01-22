    public class Foo : IFoo
    {
        private Bar _bar;
        
        public Foo()
        {
           _bar = new Bar();
        }
        
        public Foo(Bar bar)
        {
            _bar = bar;
        }
    }
