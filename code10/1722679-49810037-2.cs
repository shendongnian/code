    class Program
        {
            static void Main(string[] args)
            {
                CompB();
            }
            public static void CompB()
            {
                int[] AiB = new int[6];
                for (int i = 1; i < 3; i++)
                {
                    Random rnd = new Random();
                    int AiR = rnd.Next(0, 26);
                    AiB[i] = AiR;
                }
                //Write all values:
                for (int i = 0; i < 6; i++)
                {
                    System.Console.WriteLine("Value of {0}: {1}", i, AiB[i]);
                }
            
                System.Console.ReadKey();
            }
        }
