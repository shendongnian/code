        using System;
        using System.Runtime.CompilerServices;
        
        class Program
        {
            public static void Main()        
            {
                // Remove this comment and get a different result
                PrintLine();
            }
            
            static void PrintLine([CallerLineNumber] int line = 0)
            {
                Console.WriteLine(line);
            }
        }
