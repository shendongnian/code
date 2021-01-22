    using System;
    
    class Test
    {    
        static void Main()
        {
            string x = "hello";
            string y = string.Copy(x);
            
            Console.WriteLine(x==y); // Overload used
            Compare(x, y);
        }
    
        static void Compare<T>(T x, T y) where T : class
        {
            Console.WriteLine(x == y); // Reference comparison
        }
    }
