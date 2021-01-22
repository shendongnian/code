    using System;
    using System.Reflection;
    class Foo {}
    static class Program
    {
        static Func<T> GetFactory<T>()
        {
            return (Func<T>)GetFactory(typeof(T));
        }
        static object GetFactory(Type type)
        {
            Type funcType = typeof(Func<>).MakeGenericType(type);
            MethodInfo method = typeof(Program).GetMethod("CreateFoo",
                BindingFlags.NonPublic | BindingFlags.Static);
            return Delegate.CreateDelegate(funcType, method);
        }
        static Foo CreateFoo() { return new Foo(); }
        static void Main()
        {
            Func<Foo> factory = GetFactory<Foo>();
            Foo foo = factory();
        }
    }
