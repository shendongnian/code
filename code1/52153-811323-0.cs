    using System;
    namespace SomeNamespace {
        class Foo { }
    }
    static class Program {
        static void Main() {
            string typeName = "SomeNamespace.Foo";
            int id = 123;
            Type type = typeof(Program).Assembly.GetType(typeName);
            object obj = typeof(Program).GetMethod("SomeGenericFunction")
                .MakeGenericMethod(type).Invoke(
                    null, new object[] { id });
            Console.WriteLine(obj);
        }
        public static T SomeGenericFunction<T>(int id) where T : new() {
            Console.WriteLine("Find {0} id = {1}", typeof(T).Name, id);
            return new T();
        }
    }
