    using System;
    
    public class Base
    {
        public virtual object Foo()
        {
            Console.WriteLine("Base.Foo");
            return null;
        }
    }
    
    public class Derived : Base
    {
        public override object Foo()
        {
            Console.WriteLine("Derived.Foo");
            return null;
        }
    }
    
    class Test
    {
        static void Main()
        {
            Base b = new Derived();
            b.Foo();
        }
    }
