    Assembly mscorlib = typeof(string).Assembly;
    foreach (Type type in mscorlib.GetTypes())
    {
        Console.WriteLine(type.FullName);
    }
