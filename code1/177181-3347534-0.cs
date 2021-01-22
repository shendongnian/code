        static void Main(string[] args)
        {
            ExecuteWhile();
            ExecuteFor();
        }
        private static void ExecuteFor()
        {
            for (; ; )
            {
                Console.WriteLine("for");
                string val = Console.ReadLine();
                if (string.IsNullOrEmpty(val))
                {
                    Console.WriteLine("Exit for.");
                    break;
                }
            }
        }
        private static void ExecuteWhile()
        {
            while (true)
            {
                Console.WriteLine("while");
                string val = Console.ReadLine();
                if (string.IsNullOrEmpty(val))
                {
                    Console.WriteLine("Exit while.");
                    break;
                }
            }
        }
