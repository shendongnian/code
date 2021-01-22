    var items = stringblah.Split('\n', StringSplitOptions.RemoveEmptyEntries)
                          .Select(s => s.Trim());
    // ...
    foreach (var item in items)
    {
        Console.WriteLine(item);
    }
