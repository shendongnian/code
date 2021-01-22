    public IEnumerable<T> DedupCollection<T> ( IEnumerable<T> input ) {
        List<T> passedValues = new List<T>();
    
        //relatively simple dupe check alg used as example
        foreach( T item in input)
            if( passedValues.Contains(item) )
                continue;
            else {
                passedValues.Add(item)
                yield return item;
            }
    }
