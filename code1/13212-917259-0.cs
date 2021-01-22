    static void Linq_Deferred_Execution_Demo()
    {
        List<String> items = new List<string> { "Bob", "Alice", "Trent" };
        var results = from s in items select s;
        Console.WriteLine("Before add:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
        items.Add("Mallory");
        //
        //  Enumerating the results again will return the new item, even
        //  if we did not re-assign the Linq statement to it!
        //
        Console.WriteLine("\nAfter add:");
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
