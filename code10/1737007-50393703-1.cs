    using System;
    
    class SomeBaseType {}
    class SomeDerivedType : SomeBaseType {}
    
    static class FooExtensions
    {
        public static void Extra<T>(this Foo<T> foo)
            where T : SomeDerivedType
        {
            Console.WriteLine("You have extra functionality!");
        }
    }
    
    class Foo<T> where T : SomeBaseType
    {
    }
    
    class Program
    {
        static void Main(string[] args)        
        {
            Foo<SomeBaseType> foo1 = new Foo<SomeBaseType>();
            Foo<SomeDerivedType> foo2 = new Foo<SomeDerivedType>();
            
            // Doesn't compile: the constraint isn't met
            // foo1.Extra();
             
            // Does compile
            foo2.Extra();
        }
    }
