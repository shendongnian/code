    public static IEnumerable<T[]> AsChunks<T>(IEnumerable<T> source, int size)
    {
        var chunk = new T[size];
        var i = 0;
        foreach(var e in source)
        {
            chunk[i++] = e;
            if (i==size)
            {
                yield return chunk;
                i=0;
            }
        }
        if (i>0) // Anything left?
        {
            Array.Resize(ref chunk, i);
            yield return chunk;
        }
    }
    void Main()
    {
        foreach(var chunk in AsChunks("Hello World!",5))
            Console.WriteLine(new string(chunk));
    }
