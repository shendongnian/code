        public static int[,] TEUlayer1 = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
        public static int[,] TEUlayer2 = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 0 } };
        static void Main(string[] args)
        {
            var islands = new List<Island> { new Island(2), new Island(3), new Island(1), new Island(4), new Island(2), new Island(2), new Island(1), };
            Program.PrintLayer(TEUlayer1);
            Program.PrintLayer(TEUlayer2);
            var index = 0;
            foreach (var island in islands)
            {
                Console.WriteLine("Island {0} has a 'S8s4collection' of: {1}", index, island.S8s4collection);
                index++;
            }
            Console.ReadKey();
        }
        class Island
        {
            public int S8s4collection { get; private set; }
            public Island(int s8s)
            {
                S8s4collection = s8s;
            }
        }
        private static void PrintLayer(int[,] layer)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(layer[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
