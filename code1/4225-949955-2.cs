    public static void WriteToConsole<T>(this IList<T> collection)
    {
        WriteToConsole<T>(collection, "\t");
    }
        
    public static void WriteToConsole<T>(this IList<T> collection, string delimiter)
    {
        int count = collection.Count();
        for(int i = 0;  i < count; ++i)
        {
             Console.Write("{0}{1}", collection[i].ToString(), delimiter);
        }
        Console.WriteLine();
    }
