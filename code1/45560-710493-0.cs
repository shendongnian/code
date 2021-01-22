    using System;
    
    class Base
    {
        public virtual void Foo(int x)
        {
            Console.WriteLine("Base.Foo(int)");
        }
    }
    
    class Derived : Base
    {
        public override void Foo(int x)
        {
            Console.WriteLine("Derived.Foo(int)");
        }
        
        public void Foo(double d)
        {
            Console.WriteLine("Derived.Foo(double)");
        }
    }
    
    class Test
    {
        static void Main()
        {
            Derived d = new Derived();
            d.Foo(10);
        }
    }
