    public static class MyClassExtensions
    {
        public static void DoSomethingT<T, U>(this MyClass<T, U> obj, T t)
        {
            obj.DoSomething(t);
        }
        public static void DoSomethingU<T, U>(this MyClass<T, U> obj, U u)
        {
            obj.DoSomething(u);
        }
    }
