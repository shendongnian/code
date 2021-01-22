    Assembly assembly = Assembly.LoadFile(@"test.dll");
    foreach (Type type in assembly.GetTypes())
    {
        if (type.IsClass)
        {
            ...
        }
    }
