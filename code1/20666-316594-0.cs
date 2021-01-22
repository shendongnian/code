    static void Main(string[] args)
    {
        Arguments cmdline = new Arguments(args);
        Console.WriteLine(cmdline["name"]);
    }
