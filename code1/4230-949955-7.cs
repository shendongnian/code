    public static void WriteToConsole<T>(this IList<T> collection)
    {
        int count = collection.Count();
        for(int i = 0;  i < count; ++i)
        {
            Console.Write("{0}\t", collection[i].ToString(), delimiter);
        }
        Console.WriteLine();
    }
