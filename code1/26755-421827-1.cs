    using System;
    
    class Test
    {
        static string x;
        
        static void Main()
        {
            Console.WriteLine(Method());
            Console.WriteLine(x);
        }
        
        static string Method()
        {
            try
            {
                x = "try";
                return x;
            }
            finally
            {
                x = "finally";
            }
        }
    }
