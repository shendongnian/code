    class Foo
    {
        private Foo()
        {
        }
    
        public class Bar
        {
            public Bar()
            {
            }
    
            public Foo GetFoo()
            {
                return new Foo();
            }
        }
    }
..
    Foo.Bar fooBar = new Foo.Bar();
    Foo foo = fooBar.GetFoo();
