        Console.WriteLine("What is the name of your song");
        string name = Console.ReadLine();
...
        Console.WriteLine("Enter an artist name, or just press return for all artists");
        var name = Console.ReadLine().ToUpper();
        name = name.Trim();
