    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> values, int chunkSize)
    {
        var e = values.GetEnumerator();
        while (e.MoveNext())
        {
            yield return innerChunk(e, chunkSize);
        }
    }
    
    private static IEnumerable<T> innerChunk<T>(IEnumerator<T> e, int chunkSize)
    {
        //If we're here, MoveNext() was already called once to advance between batches
        // Need to yield the value from that call.
        yield return e.Current;
        //start at 1, not 0, for the first yield above  
        int i = 1; 
        while(i++ < chunkSize && e.MoveNext()) //order of these conditions matters
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
