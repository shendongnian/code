    List<string> names = new List<string> { "First", "Second", "Third" };
    foreach (string x in names)
    {
        foreach(string y in names)
        {
            Console.WriteLine("{0} {1}");
        }
    }
