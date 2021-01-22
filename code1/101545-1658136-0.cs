    static void Main(string[] arguments)
    {
        int i = 0;
        string s = "";
        Test(i);
        Test(s);
        Console.ReadLine();
    }
    static void Test<T>(T arg)
    {
        Console.WriteLine(arg.GetType());
    }
