    var result = upperActionRoles
                 .Where(entry => lowerActionRoles.ContainsKey(entry.Key) && !lowerActionRoles[entry.Key].SequenceEqual(entry.Value))
                 .ToDictionary(entry => entry.Key, entry => entry.Value);
    foreach (var item in result)
    {
        Console.WriteLine("Key: " + item.Key);
        Console.WriteLine();
        item.Value.ForEach(x => Console.WriteLine("Value: " + x));
    }
    
    Console.ReadLine();
