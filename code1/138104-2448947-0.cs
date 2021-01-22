    using System;
    
    class Test
    {
        static void Main()
        {
            Array nonZeroBase = Array.CreateInstance
               (typeof(byte), new int[]{1}, new int[]{2});
            Console.WriteLine(nonZeroBase); // Prints byte[*]
        }
    }
