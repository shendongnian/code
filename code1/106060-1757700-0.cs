    [DllImport("libfoo")]
    static extern int foo(StringBuilder name);
    static void Main()
    {
        StringBuilder name = new StringBuilder(100);
        foo(name);
        Console.WriteLine(name);
    }
