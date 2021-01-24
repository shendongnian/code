    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            List<string> x = new List<string>();
            List<string> y = x;
            // x and y now refer to the same list...
            
            x.Add("foo");
            Console.WriteLine(y.Count); // 1
            
            y.Clear();
            Console.WriteLine(x.Count); // 0
            
            // Changing x or y to refer to a different list
            // *doesn't* change the other variable
            x = new List<string>();
            x.Add("bar");
            x.Add("baz");
            
            Console.WriteLine(y.Count); // 0
        }
    }
