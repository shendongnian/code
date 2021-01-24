    using System;
    namespace Zadacha
    {
        class Zadacha
        {
            static int Read()
            {
                int x = 0;
                int y = 0;
                Random rnd = new Random();
                Console.WriteLine("Vuvedete minimalna velichina");
                string MinValue = Console.ReadLine();
                Console.WriteLine("Vuvedete maximalna velichina");
                string MaxValue = Console.ReadLine();
                int.TryParse(MinValue, out x);
                int.TryParse(MaxValue, out y);
                int value = rnd.Next(x, y);
                Console.WriteLine("Proizvodnoto chislo e: " + value);
                Console.ReadKey(true);
                return value;
            }
            static void Main()
            {
                Read();
            }   
        }
    }
