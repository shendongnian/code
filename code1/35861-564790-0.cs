    using System;
    
    class Test
    {
        static int x = 5;
        static int y = x;
        
        static void Main()
        {
            // Prints x=5 y=5
            Console.WriteLine("x={0} y={1}", x, y);
        }
    }
