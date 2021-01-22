    public static void Run()
    {
        var derived = new Derived();
        Console.WriteLine(derived.Id); // prints "hi"
        derived.changeParentVariable();
        Console.WriteLine(derived.Id); // prints "sup"
    }
