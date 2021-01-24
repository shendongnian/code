    var mainCollection = new List<string[]> { new string[] { "Employee1" },
                                              new string[] { "Employee2" }};
    for (int i = 0; i < mainCollection.Count; i++) 
    {
        Console.WriteLine(string.Join(", ", mainCollection[i]));
    }
    Console.ReadKey();
