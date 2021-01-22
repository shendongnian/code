    public IEnumerable<T> DedupCollection<T> ( IEnumerable<T> input ) {
        HashSet<T> passedValues = new HashSet<T>();
    
        //relatively simple dupe check alg used as example
        foreach( T item in input)
            if( passedValues.Contains(item) )
                continue;
            else {
                passedValues.Add(item)
                yield return item;
            }
    }
