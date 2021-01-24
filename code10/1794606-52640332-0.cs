    var items = new List<string>();
    items.AddRange(Enumerable.Repeat(string.Empty, 10));
    Console.WriteLine(items.Count);
    items.Insert(5, "TestString");
    Console.WriteLine(items.Count);
