    public class Foo<T> : AbstractFoo where T : IParam
    {
        public Foo(T param) : base(param)
        { }
    }
