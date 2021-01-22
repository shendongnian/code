    public static void Run()
    {
        var derived = new Derived();
        Console.WriteLine(derived.Id);
        derived.changeParentVariable();
        Console.WriteLine(derived.Id);
    }
