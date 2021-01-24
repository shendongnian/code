    string json = File.ReadAllText(IFSCCodeFile);
    
    Rooot rooot = JsonConvert.DeserializeObject<Rooot>(json);
    
    foreach (var item in rooot.Result)
    {
        Console.WriteLine(item.Key);
        Console.WriteLine(item.Value.BANK ?? "NULL");
        Console.WriteLine(item.Value.IFSC ?? "NULL");
        Console.WriteLine(item.Value.BRANCH ?? "NULL");
        Console.WriteLine(item.Value.ADDRESS ?? "NULL");
        Console.WriteLine(item.Value.CONTACT ?? "NULL");
        Console.WriteLine(item.Value.CITY ?? "NULL");
        Console.WriteLine(item.Value.DISTRICT ?? "NULL");
        Console.WriteLine(item.Value.STATE ?? "NULL");
        Console.WriteLine();
    }
    
    Console.ReadLine();
