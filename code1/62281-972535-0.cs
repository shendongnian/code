    using System;
    using System.Collections.Generic;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Base b = new Base();
                Derived1 d1 = new Derived1();
                Derived2 d2 = new Derived2();
                Console.ReadKey(true);
            }
        }
    
        class Base
        {
            public Base()
            {
                Console.WriteLine("Base Constructor. Calling type: {0}", this.GetType().Name);
            }
        }
    
        class Derived1 : Base { }
        class Derived2 : Base { }
    }
