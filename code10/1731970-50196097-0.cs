    var name = Console.ReadLine();
    if (!dict.KeyExists(name))
    {
        Console.WriteLine("The Box {0} does not exist", name);
    }
    else
    {
        var target = dict[name];
        // ...
    }
