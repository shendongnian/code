    using System;
    
    class First
    {
        static int a = 10;
        public static int b = CalculateB();
        static int c = 5;
        
        static int CalculateB()
        {
            return a*c;
        }
    }
    
    class Second
    {
        static int a = 10;
        static int c = 5;
        public static int b = CalculateB();
        
        static int CalculateB()
        {
            return a*c;       
        }
    }
    
    class Test
    {
        static void Main()
        {
            Console.WriteLine("First.b: {0}, Second.b: {1}",
                              First.b, Second.b);
        }
    }
