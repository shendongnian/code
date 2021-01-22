    using System;
    class Program
    {
        unsafe static int Main(string[] args)
        {
            fixed (int* test = new int[10])
            {
                for (int i = 0; i < 10; i++)
                    test[i] = i * 10;
                Console.WriteLine(test[5]); // 50
                Console.WriteLine(*(5+test)); // Works with this syntax
            }
            return (int)Console.ReadKey().Key;
        }
    }
