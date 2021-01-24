    class Program
        {
            static void Main(string[] args)
            {
                int[,] array = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 } };
                int[] vector = array.Cast<int>().ToArray();
                Console.ReadKey();
            }
        }
