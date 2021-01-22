    using System;
    namespace MyNamespace {
        public class Foo {
            public void Bar() {
                Console.WriteLine("Foo.Bar called");
            }
        }
    }
    class Program {
        static void Main() {
            string className = "MyNamespace.Foo, MyAssemblyName",
                methodName = "Bar";
            Type type = Type.GetType(className);
            object obj = Activator.CreateInstance(type);
            type.GetMethod(methodName).Invoke(obj, null);
        }
    }
