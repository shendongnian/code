    class Program
    {
        static void Main(string[] args)
        {
            int product = Grid.ToList().Max(t => t.Item1 * t.Item2 * t.Item3 * t.Item4);
            Console.WriteLine("Maximum product is {0}", product);
        }
    }
