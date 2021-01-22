    IList<Object> collection = new List<Object> { 
        new Object(), 
        new Object(), 
        new Object(), 
        };
    foreach (Object o in collection)
    {
        Console.WriteLine(collection.IndexOf(o));
    }
    Console.ReadLine();
