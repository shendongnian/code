    System.Collections.IEnumerable collection = Enumerable.Range(100, 10);
    foreach (var o in collection.OfType<object>().Select((x, i) => new {x, i}))
    {
        Console.WriteLine("{0} {1}", o.i, o.x);
    }
