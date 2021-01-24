    public static void Main(string[] args)
    {
        Console.WriteLine("Begin");
        var data = new List<double>;
        var input = Console.ReadLine();
        while (!input.Equals("exit", StringComparison.OrdinalIgnoreCase) 
            && !input.Equals("continue", StringComparison.OrdinalIgnoreCase))
        {
            data.Add(double.Parse((input));
            input = Console.ReadLine();       
        }
        for (double d in data)
        {
            Console.WriteLine(d);
        }
    }
