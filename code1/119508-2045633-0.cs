    using System;
    
    class Program {
        static void Main(string[] args) {
            for (int ix = 0; ix < Console.WindowWidth - 1; ++ix)
                Console.Write('\u2500');
            Console.WriteLine();
            Console.ReadLine();
        }
    }
