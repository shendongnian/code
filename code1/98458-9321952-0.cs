    foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
    {
        Console.WriteLine(a.GetName().FullName);
        Console.WriteLine(a.Location);
        Console.WriteLine();
    }
