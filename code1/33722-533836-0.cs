    foreach (Type type in assembly.GetTypes())
    {
        if (type.IsClass && type.BaseType == typeof(object))
        {
            Console.WriteLine(type);
        }
    }
