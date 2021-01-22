    foreach(var item in collection.ToNavigable())
    {
        if (item.IsFirst) { ... }
        if (item.IsLast) { ... }
        if (item.IsEven) { ... }
        if (item.IsOdd) { ... }
        Console.WriteLine(item.Value);
    }
