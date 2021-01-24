    using System;
    namespace Demo
    {
        public class BaseClass
        {
            public static string Get => "";
        }
        public class Class1 : BaseClass
        {
            public new static string Get => "hello";
        }
        public class Class2 : BaseClass
        {
            public new static string Get => "world";
        }
        public class Testing<T> where T : BaseClass
        {
            public string Test()
            {
                var property = typeof(T).GetProperty("Get");
                if (property != null)
                    return (string) property.GetValue(null, null);
                return null;
            }
        }
        class Program
        {
            static void Main()
            {
                var test1 = new Testing<Class1>();
                Console.WriteLine(test1.Test());  // Prints "hello"
                var test2 = new Testing<Class2>();
                Console.WriteLine(test2.Test()); // Prints "world"
            }
        }
    }
