    using System;
    using System.Linq.Expressions;
    
    public class Base
    {
        public void Foo(Action action)
        {
            Console.WriteLine("I suspect the lambda expression...");
        }
    }
    
    public class Derived : Base
    {
        public void Foo(Action<int> action)
        {
            Console.WriteLine("I suspect the anonymous method...");
        }
    }
     
    class Test
    {
        static void Main()
        {
            Derived d = new Derived();
            int x = 0;
            d.Foo( () => { x = 0; } );
            d.Foo( delegate { x = 0; } );
        }
    }
