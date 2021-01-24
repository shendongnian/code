    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> values, int chunkSize)
    {
        var e = values.GetEnumerator();
        while (e.MoveNext())
        {
            yield return innerChunk(e, e.Current, chunkSize);
        }
    }
    
    private static innerChunk<T>(IEnumerator<T> e, T initialValue, int chunkSize)
    {
        yield return e.Current;
        int i = 1; //1, not 0, for the first yield above
    
        while(e.MoveNext() && i++ < chunkSize)
        {
            yield return e.Current;
        }
    }
        
    public static void WriteFormattedTextToNewFile(IEnumerable<string> groupedStrings)
    {
        string file = @"C:\Users\e011691\Desktop\New folder\formatted.txt";
        using (var sw = new StreamWriter(file, true))
        {   
            foreach(var strings in groupedStrings.Chunk(50))
            {
                sw.Write($"{DateTime.Now:yyyy MM dd  hh:mm:ss}\t\t");
                foreach(var item in strings)
                {
                   sw.Write($"{item}\t");
                }
                sw.WriteLine();
            } 
        }
    }
