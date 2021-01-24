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
            Console.WriteLine(AiB[0]);
            Console.ReadKey();
        }
    }
