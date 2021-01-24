    public class Foo<T> : AbstractFoo where T : IParams
    {
        public Foo(T param) : base(param)
        { }
    }
