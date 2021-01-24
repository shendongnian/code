    public interface IBaseWrapper<TWrapper, T> where TWrapper : IBaseWrapper<TWrapper, T>
    {
        IBaseWrapper<TWrapper, T> Baz();
    }
    public interface IFooWrapper : IBaseWrapper<IFooWrapper, Foo>
    {
        void FooSpecificMethod();
    }
    public class BaseWrapper<TWrapper, T> : IBaseWrapper<TWrapper, T> where TWrapper : BaseWrapper<TWrapper, T> where T : class
    {
        private T _instance;
        public BaseWrapper(T instance)
        {
            _instance = instance;
        }
        public TWrapper Baz()
        {
            // note whatever wrapper class you are using must have a
            // constructor matching this base class
            return Activator.CreateInstance(GetType(), new object[] { _instance });
        }
    }
    public class FooWrapper : BaseWrapper<FooWrapper, Foo>, IFooWrapper
    {
        public FooWrapper(Foo instance) : base(instance)
        {
        }
        public void FooSpecificMethod()
        {
            // foo stuff
        }
    }
