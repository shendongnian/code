    Assembly myAssembly;
    Type myInterface;
    foreach (Type type in myAssembly.GetTypes())
    {
        if (myInterface.IsAssignableFrom(type))
            Console.WriteLine(type.FullName);
    }
