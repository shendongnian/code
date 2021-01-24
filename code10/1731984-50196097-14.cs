    Box target = null;
    while(true)
    {
        Console.WriteLine("Enter the name of the Box:");
        var name = Console.ReadLine();
        if (dict.KeyExists(name))
        {
            target = dict[name];
            break;
        }
        Console.WriteLine("The Box {0} does not exist", name);
    }
