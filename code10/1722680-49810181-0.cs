    static void Main(string[] args)
            {`enter code here`
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
                System.Console.WriteLine(AiB[1]);
                System.Console.ReadKey();
            }
