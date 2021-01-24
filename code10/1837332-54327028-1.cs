    foreach (var item in result)
    {
        Console.WriteLine("Key: " + item.Key);
        Console.WriteLine();
        item.Value.ForEach(x => Console.WriteLine("Value: " + x));
    }
    
    Console.ReadLine();
