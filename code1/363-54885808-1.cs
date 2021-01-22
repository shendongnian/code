    var items = new Dictionary<string, int>();
    items.Add("cat", 0);
    items.Add("dog", 20);
    items.Add("bear", 100);
    items.Add("lion", 50);
    // Call OrderBy method here on each item and provide them the ids.
    foreach (var item in items.OrderBy(k => k.Key))
    {
        Console.WriteLine(item);// items are in sorted order
    }
