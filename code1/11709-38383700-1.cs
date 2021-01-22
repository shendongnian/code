    static void Main(string[] args)
    {
        decimal notTooLarge = 1000000.99m;
        Console.WriteLine(ValueIsTooLarge(notTooLarge, 9, 2));
        decimal tooLarge = 1000000.991m;
        Console.WriteLine(ValueIsTooLarge(tooLarge, 9, 2));
        Console.ReadKey();
    }
