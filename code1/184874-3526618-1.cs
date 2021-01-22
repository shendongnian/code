    static void Main()
    {
        var input = new[] { "one", "two", @"three ""with quotes""!", "↑" };
        Console.WriteLine(input.ToJson());
        Console.ReadLine();
    }
