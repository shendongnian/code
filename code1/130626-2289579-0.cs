    public interface IResolver
    {
        T Resolve<T>();
    }
    void foo(IResolver resolver)
    {
        MyType x = resolver.Resolve<MyType>();
        MyOtherType y = resolver.Resolve<MyOtherType>();
    }
