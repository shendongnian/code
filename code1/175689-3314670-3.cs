    static void Main(string[] args)
    {
        object A = new object();
        object B = new object();
        object C = new object();
        object D = new object();
        object[] list = new object[] {A, B, C, D };
        Console.WriteLine(ContainsSequence(list, B, C));
        Console.WriteLine(ContainsSequence(list, A, D));
        Console.WriteLine(ContainsSequence(list, C, D));
        Console.ReadKey();
    }
