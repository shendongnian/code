    using System;
    
    namespace TestOverflow
    {
        class Program
        {
            static void Main(string[] args)
            {
                short x = 20000;
                short y = 20000;
                short z;
    
                Console.WriteLine("Overflowing with default behavior...");
                z = (short)(x + y);
                Console.WriteLine("Okay! Value is {0}. Press any key to overflow " +
                    "with 'checked' keyword.", z);
                Console.ReadKey(true);
    
                z = checked((short)(x + y));
            }
        }
    }
