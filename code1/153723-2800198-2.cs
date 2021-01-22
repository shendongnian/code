    using System;
    namespace MyNamespace {
        public class Foo {
            public void Bar(string value) {
                Console.WriteLine("Foo.Bar called: " + value);
            }
        }
    }
    class Program {
        static void Main() {
            string className = "MyNamespace.Foo, MyAssemblyName",
                methodName = "Bar";
            Type type = Type.GetType(className);
            object obj = Activator.CreateInstance(type);
            object[] args = { "hello, world" };
            type.GetMethod(methodName).Invoke(obj, args);
        }
    }
