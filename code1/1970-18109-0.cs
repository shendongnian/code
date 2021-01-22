    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                MyClass foo = new MyClass();
    
                Console.ReadLine();
            }
        }
    
        class BaseClass
        {
            public BaseClass()
            {
                Console.WriteLine("BaseClass constructor called.");
            }
        }
    
        class MyClass : BaseClass
        {
            public MyClass()
            {
                Console.WriteLine("MyClass constructor called.");
            }
        }
    }
