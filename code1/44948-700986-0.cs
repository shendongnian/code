    public static class Foo
    {
        public static Foo<T> CreateInstance(IGenericType<T> instance)
        {
            return new Foo<T>(instance);
        }
    }
    public class Foo<T>
    {
        public Foo(IGenericType<T> instance)
        {
            // Whatever
        }
    }
    ...
    IGenericType<string> x = new GenericType<string>();
    Foo<string> noInference = new Foo<string>(x);
    Foo<string> withInference = Foo.CreateInstance(x);
