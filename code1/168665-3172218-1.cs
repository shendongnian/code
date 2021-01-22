    public abstract class Foo
    {
        [Inject]
        public Bar Bar {get; set;}
    }
    public class Baz : Foo
    {
        ...
    }
    public class SomeUtil
    {
        Baz _baz;
        public SomeUtil(Baz baz)
        {
            _baz = baz;
        }
    }
