    Assembly mscorlib = typeof(int).Assembly;
    Console.Write("Type name? ");
    string typeName = Console.ReadLine();
    Type type = mscorlib.GetType(typeName);
    foreach (MethodInfo method in type.GetMethods())
    {
        Console.WriteLine(method);
    }
