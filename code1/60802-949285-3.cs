    Type[] typelist = GetTypesInNamespace(Assembly.GetExecutingAssembly(), "MyNamespace");
    for (int i = 0; i < typelist.Length; i++)
    {
        Console.WriteLine(typelist[i].Name);
    }
    
