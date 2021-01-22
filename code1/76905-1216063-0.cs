    using System;
    
    public class Test
    {
        static void Main()
        {
            bool condition = true;
            bool condition1 = true;
            bool condition2 = false;
            
            if (condition)
            {
                if (condition1)
                {
                    Console.WriteLine("condition1");
                }
                // Note the "else if" here.
                else if (condition2) {
                    Console.WriteLine("condition2");
                }
                else 
                {
                    Console.WriteLine("neither");
                }
            }
        }
    }
