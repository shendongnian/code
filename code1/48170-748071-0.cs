    foreach (var type in assembly.GetTypes())
    {
        var myInterfaceType = typeof(IMyInterface);
        if (type != myInterfaceType && myInterfaceType.IsAssignableFrom(type))
        {
            Console.WriteLine("{0} implements IMyInterface", type);
        }
    }
