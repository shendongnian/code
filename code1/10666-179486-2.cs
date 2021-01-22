    using System;
    using System.Reflection;
    using System.Runtime.Serialization;
    namespace NoConstructorThingy
    {
        class Program
        {
            static void Main()
            {
                // does not call ctor
                var myClass = (MyClass)FormatterServices.GetUninitializedObject(typeof(MyClass));
                Console.WriteLine(myClass.One); // writes "0", constructor not called
                Console.WriteLine(myClass.Two); // writes "2", field initializers is called
            }
        }
        public class MyClass
        {
            public MyClass()
            {
                Console.WriteLine("MyClass ctor called.");
                One = 1;
            }
            public int One { get; private set; }
            public readonly int Two = 2;
        }
    }
