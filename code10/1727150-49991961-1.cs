    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello World!");
                Console.WriteLine($"132 = {string.Join(",", ConvertToArray(132))}");
                Console.ReadKey();
            }
    
            static bool[] ConvertToArray(short @short)
            {
                var result = new bool[16];
                for (int i = 0; i < 16; i++)
                {
                    result[i] = (@short & (short)1) == (short)1 ? true : false;
                    @short = (short)(@short >> 1);
                }
                return result;
            }
    
        }
    }
