    foreach (Type t in typeof(object).Assembly.GetTypes())
    {
        if (t.IsPublic && typeof(Delegate).IsAssignableFrom(t))
            Console.WriteLine(t.Name);
    }
