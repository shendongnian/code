    using System;
    
    class MyClass<T> {}
    class AnotherClass : MyClass<string> {}
    
    public class Test
    {
        static void Main()
        {
            // Prints MyClass`1[String]
            Console.WriteLine(typeof(AnotherClass).BaseType);
        }
    }
