    public IEnumerable<T> DedupCollection<T> (IEnumerable<T> input) 
    {
        var passedValues = new HashSet<T>();
    
        // Relatively simple dupe check alg used as example
        foreach(T item in input)
            if(passedValues.Add(item)) // True if item is new
                yield return item;
    }
