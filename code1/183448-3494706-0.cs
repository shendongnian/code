    List<string> items = new List<string>(); 
    items.Add("Foo");
    items.Add("Bar");
    items.Add("Baz");
    foreach (string item in items.OrderBy(c => Guid.NewGuid()))
    {
        Console.WriteLine(item);
    }
