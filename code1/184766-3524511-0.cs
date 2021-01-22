    //Remove "this" if you don't want it to be a extension method
    public static IEnumerable<IList<T>> Chunks<T>(this IEnumerable<T> xs, int size)
    {
        int i = 0;
    
        var curr = new List<T>(size);
    
        foreach (var x in xs)
        {
            curr.Add(x);
            
            if (++i % size == 0)
            {
                yield return curr;
                curr = new List<T>(size);
            }
        }
    }
