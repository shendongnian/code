    public class Program
    {
        public static int[,] TeuLayer1 = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 } };
        public static int[,] TeuLayer2 = new int[4, 4] { { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 1 }, { 1, 1, 1, 0 } };
        public static List<Island> Islands = new List<Island> { new Island(2), new Island(3), new Island(1), new Island(4), new Island(2), new Island(2), new Island(1) };
        static void Main(string[] args)
        {
            Program.PrintLayer(Program.TeuLayer1);
            Program.PrintLayer(Program.TeuLayer2);
            Program.PrintIsland(Program.Islands);
            Console.ReadKey();
        }
        public class Island
        {
            public int S8s4collection { get; private set; }
            public Island(int s8s)
            {
                S8s4collection = s8s;
            }
        }
        private static void PrintIsland(IEnumerable<Island> islands)
        {
            var index = 0;
            foreach (var island in islands)
            {
                Console.WriteLine("Island {0} has a 'S8s4collection' of: {1}", index, island.S8s4collection);
                index++;
            }
            Console.WriteLine();
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
    }
