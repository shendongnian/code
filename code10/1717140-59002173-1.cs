    static void Main(string[] args)
    {
        Func<int, double> func = new Func<int, double>(CalculateHra);
        Console.WriteLine(func(50000));
        Console.Read();
    }
    
    static double CalculateHra(int basic)
    {
        return (double)(basic * .4);
    }
