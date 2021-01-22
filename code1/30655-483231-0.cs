    using System;
    using System.Reflection;
    
    namespace Foo
    {
        class Test
        {
            static void Main()
            {
                Type type = Type.GetType("Foo.MyClass");
                object instance = Activator.CreateInstance(type);
                MethodInfo method = type.GetMethod("MyMethod");
                method.Invoke(instance, null);
            }
        }
        
        class MyClass
        {
            public void MyMethod()
            {
                Console.WriteLine("In MyClass.MyMethod");
            }
        }
    }
