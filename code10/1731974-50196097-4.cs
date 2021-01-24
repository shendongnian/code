    Console.WriteLine("Enter the name of the Box:");
    var name = Console.ReadLine();
    if (dict.KeyExists(name))
    {
        var target = dict[name];
        // ...
    }
    else
    {
        Console.WriteLine("The Box {0} does not exist", name);
    }
