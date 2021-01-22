    static void Main(string[] args)
    {
        var file = new StreamReader("scores.txt");
        var split = file.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);            
        IEnumerable<int> ints = split.Select(x => int.Parse(x));
        Console.WriteLine("Total Scores:" + ints.Count());
        Console.WriteLine("Max:" + ints.Max());
        Console.WriteLine("Min:" + ints.Min());
        Console.WriteLine("Average:" + ints.Average().ToString("0.00"));
        Console.ReadLine();
    }
