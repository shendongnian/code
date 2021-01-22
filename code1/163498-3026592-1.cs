    var xs = new StringCollection { "House", "Car", "House", "Dog", "Cat" };
    foreach (var g in xs.Cast<string>()
                        .GroupBy(x => x, StringComparer.CurrentCultureIgnoreCase))
    {
        Console.WriteLine("{0}: {1}", g.Key, g.Count());
    }
