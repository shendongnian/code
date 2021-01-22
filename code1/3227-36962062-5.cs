    static void Main(string[] args)
    {
        testA();
        Console.Write("try again. the above won't execute any of the function!\n");
        foreach (var x in testA()) { }
        Console.ReadLine();
    }
    // static List<int> testA()
    static IEnumerable<int> testA()
    {
        Console.WriteLine("asdfa");
        yield return 1;
        Console.WriteLine("asdf");
    }
