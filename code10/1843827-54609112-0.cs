    static void Print<T>(this IEnumerable<T> source)
    {
        foreach(var q in source)
        {
            Console.WriteLine(q); // implicitly calls T.ToString();
        }
        Console.WriteLine();
        var count = source.Count();
        Console.WriteLine("The query pulls: {0} results.", count);
        Console.WriteLine();
    }
 
