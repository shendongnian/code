    using System;
    
    class Test
    {
        static int y = x;
        static int x = 5;
        
        static void Main()
        {
            // Prints x=5 y=0
            Console.WriteLine("x={0} y={1}", x, y);
        }
    }
