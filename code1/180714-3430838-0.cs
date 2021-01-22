    public class Foo
    {
        private readonly int _bar;
        Foo(int bar)
        {
            _bar = bar;
        }
        /* other code that makes this class actually interesting. */
    }
    
    public class UsesFoo
    {
        public void FooUsedHere(int param)
        {
            Foo baz = new Foo(param)
            //Do something here
            //baz falls out of scope and is liable to GC colleciton
        }
    }
