    private static void Main(string[] args)
    {
        var A = new object();
        var B = new object();
        var C = new object();
        var D = new object();
        var list = new[] {A, B, C, D};
        Console.WriteLine(ContainsSequence(list, B, C, D));
        Console.WriteLine(ContainsSequence(list, A, D, C, B, A, C));
        Console.WriteLine(ContainsSequence(list, A, B));
    }
