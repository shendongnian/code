    using System;
    
    namespace CodeProfiler
    {
        class Program
        {
            static void Main(string[] args)
            {
                Action action = () =>
                {
                    for (int i = 0; i < 10000000; i++)
                        Math.Sqrt(i);
                };
    
                for(int i=1; i<=16; i++)
                    Console.WriteLine(i + " thread(s):\t" + CodeProfiler.ProfileAction(action, 100, i));
    
                Console.Read();
            }
        }
    }
