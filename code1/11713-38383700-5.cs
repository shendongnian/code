    static void Main(string[] args)
    {
        decimal valid = 1000000.99m;
        Console.WriteLine($"Is {valid} valid? {IsValid(valid, 9, 2)}");
        decimal invalid = 1000000.991m;
        Console.WriteLine($"Is {invalid} valid? {IsValid(invalid, 9, 2)}");
        Console.ReadKey();
    }
