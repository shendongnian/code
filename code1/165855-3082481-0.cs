    foreach (var group in lookup)
    {
        Console.WriteLine(group.Key);
        foreach (string value in group)
        {
            Console.WriteLine("  " + value);
        }
    }
