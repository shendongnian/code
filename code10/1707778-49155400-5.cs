    public interface IBaz
    {
        void Baz();
    }
    public interface IBaseWrapper<TWrapper, T> where TWrapper : IBaseWrapper<TWrapper, T> where T : IBaz
    {
        void Baz();
    }
    public class BaseWrapper<TWrapper, T> : IBaseWrapper<TWrapper, T> where TWrapper : BaseWrapper<TWrapper, T> where T : class, IBaz
    {
        private T _instance;
        public BaseWrapper(T instance)
        {
            _instance = instance;
        }
        public void Baz()
        {
            _instance.Baz();
        }
    }
    public class Foo : IBaz
    {
        public void Baz()
        {
            // baz it up
        }
    }
    public class FooWrapper : BaseWrapper<FooWrapper, Foo>
    {
        public FooWrapper(Foo instance) : base(instance)
        {
        }
    }
