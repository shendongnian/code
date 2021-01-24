    using System;
    
    namespace ConsoleApp
    {
        class Test
        {
            static void Main()
            {
                double num;
                var isConversionSucceed = double.TryParse(Console.ReadLine(), out num);
                if (isConversionSucceed)
                {
                    Console.WriteLine((int)num);
                }
                else
                {
                    Console.WriteLine("Input Conversion failed!");
                }
    
                Console.ReadLine();
            }
        }
    }
