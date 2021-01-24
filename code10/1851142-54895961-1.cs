       static void Main(string[] args)
        {
    
            Random rnd = new Random(Environment.TickCount);
    
            
            double iterations = 1000;
            for (int z = 0; z < 10; z++)
            {
                double totalSum = 0;
                int bigWins = 0;
                iterations *= 10;
                for (double i = 1; i < iterations; i++)
                {
                    int sum = 2;
                    int a = 1;
                    
                    while (a == 1)
                    {
                        //generate a random number between 1 and 2
                        a = rnd.Next(1, 3);
                        
    
                        if (a == 1)
                        {
                            sum *= 2;
                        }
                        if (sum > 8000)
                        {
                            // if the sum is over 8000 that means that it scored 1 12 times in a row (2^12) - that should happen
                            //once every 4096 times. Given that we run the simulation 100 000 000 times it should hover around 
                            // 100 000 000/4096
                            bigWins++;
                            break;
                        }
                    }
    
                    totalSum += sum;
            
                }
    
                Console.WriteLine("Average gain over : " + iterations + " iterations is:" + totalSum / iterations);
                Console.WriteLine("Expected big wins: " + iterations / 4096 + " Actual big wins: " + bigWins);
                Console.WriteLine();
            }
    
    
            Console.ReadKey();
        }
