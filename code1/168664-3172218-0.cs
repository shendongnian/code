    public abstract class Foo
    {
        [Inject]
        public Bar {get; set;}
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
