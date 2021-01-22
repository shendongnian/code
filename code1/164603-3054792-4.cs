    foreach (var item in ForEachHelper.WithIndex(collection))
    {
        Console.Write("Index=" + item.Index);
        Console.Write(";Value= " + item.Value);
        Console.Write(";IsLast=" + item.IsLast);
        Console.WriteLine();
    }
