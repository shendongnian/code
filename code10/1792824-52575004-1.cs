    var mainCollection = new List<string[]> { new { "Employee1" },
                                              new { "Employee2" }};
    for (int i = 0; i < mainCollection.Count; i++) 
    {
        Console.WriteLine(string.Join(", ", mainCollection[i]));
    }
    Console.ReadKey();
