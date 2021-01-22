    using System;
    
    class TypeA {}
    class TypeB : TypeA {}
    
    class Program
    {
        static void Foo(TypeA x)
        {
            Console.WriteLine("Foo(TypeA)");
        }
        
        static void Foo(TypeB x)
        {
            Console.WriteLine("Foo(TypeB)");
        }
        
        static void Main()
        {
            Foo(null); // Prints Foo(TypeB)
        }
    }
