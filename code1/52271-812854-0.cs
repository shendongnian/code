    using System;
    
    enum Demo { Foo, Bar, Baz };
    
    class Test
    {
        static void Main()
        {
            int i = 2;
            object o = i;
            // Unboxing from int to Demo
            Demo d = (Demo) o;
            Console.WriteLine(d);
            
            o = Demo.Baz;
            // Unboxing from Demo to int
            i = (int) o;
            Console.WriteLine(i);
            
            // Implicit conversion of 0
            d = 0;
            Console.WriteLine(d);
        }
    }
