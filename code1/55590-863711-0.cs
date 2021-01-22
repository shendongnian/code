    using System;
    
    class Test
    {
        static void Main()
        {
            // Valid - it infers Foo<int>
            DoSomething<int>(Foo);
            // Valid - both are specified
            DoSomething<int>(Foo<int>);
            // Invalid - type inference fails
            DoSomething(Foo<int>);
            // Invalid - mismatched types, basically
            DoSomething<int>(Foo<string>);
        }
        
        static void Foo<T>(T input)
        {
        }
        
        static void DoSomething<T>(Action<T> action)
        {
            Console.WriteLine(typeof(T));
        }
    }
