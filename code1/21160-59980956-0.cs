        static void Main(string[] args)
        {
            bool isBreak = false;
            for (int i = 0; ConditionLoop(isBreak, i, 500); i++)
            {
                Console.WriteLine($"External loop iteration {i}");
                for (int j = 0; ConditionLoop(isBreak, j, 500); j++)
                {
                    Console.WriteLine($"Inner loop iteration {j}");
                    
                    // This code is only to produce the break.
                    if (j > 3)
                    {
                        isBreak = true;
                    }                  
                }
                Console.WriteLine("The code after the inner loop will be executed when breaks");
            }
            Console.ReadKey();
        }
        private static bool ConditionLoop(bool isBreak, int i, int maxIterations) => i < maxIterations && !isBreak;   
