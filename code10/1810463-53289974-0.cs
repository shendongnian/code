    static void Main(string[] args)
    {
        var possibilities = new[] {
            new[] {1, 1, 0, 1, 1, 0, 0, 0},
            new[] {1, 1, 0, 1, 1, 0, 0, 1},
            new[] {0, 1, 1, 0, 1, 1, 0, 1}
        };
        IList<int> output = new List<int>();
        for (int i = 0; i < possibilities[0].Length; i++)
        {
             output.Add(possibilities.All(x => x.ElementAt(i) == possibilities[0][i]) ? 1 : 0);
        }
        Console.WriteLine("[{0}]", string.Join(", ", output));
        Console.ReadKey();
    }
