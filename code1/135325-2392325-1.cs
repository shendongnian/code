    static void Main(string[] args)
    {
        var originalConnectionString = "original string";
        var protector = new ConnectionStringProtector();
        var protectedString = protector.Protect(originalConnectionString);
        Console.WriteLine(protectedString);
        Console.WriteLine();
        var unprotectedConnectionString = protector.Unprotect(protectedString);
        Console.WriteLine(unprotectedConnectionString);
        Console.WriteLine("Press ENTER to finish");
        Console.ReadLine();
    }
