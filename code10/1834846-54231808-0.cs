    using System.Collections.Generic;
    using System;
    
    namespace Degubbing
    {
        class DebugProgram
        {
            static void Main(string[] args)
            {
                List<int> Numbers = new List<int> { };
    
                int Seed = DateTime.Now.Millisecond;
                Random Generator = new Random(Seed);
    
                for (int i = 0; i < 10; i++)
                {
                    int RandomNum = Generator.Next(10000000, 20000000);
                    string Result = RandomNum.ToString();
                    Result = Result.Remove(Result.Length - 1);
                    Result = Result + Result[0];
                    Console.WriteLine(Result);
                }
    
                Console.ReadKey();
            }
        }
    }
