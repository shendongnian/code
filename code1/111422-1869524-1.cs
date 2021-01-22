    for (int i = 0; i < 10; i++)
    {
        Dictionary<string, string> test = new Dictionary<string, string>();
        System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();
        test.Add("fieldName", "fieldValue");
        test.Add("Title", "fieldavlkajlkdjflkjalkjslkdjfiajwelkrjelrkjavoijl");
        Console.WriteLine(watch.Elapsed);
    }
    Console.ReadKey();
