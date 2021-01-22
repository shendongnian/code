    using System;
    using System.Linq.Expressions;
    
    public class Test
    {
        static void Main()
        {
            int x = 0;
            Foo( () => x );
            Foo( delegate { return x; } );
        }
        
        static void Foo(Func<int, int> action)
        {
            Console.WriteLine("I suspect the anonymous method...");
        }
        
        static void Foo(Expression<Func<int>> func)
        {
            Console.WriteLine("I suspect the lambda expression...");
        }
    }
