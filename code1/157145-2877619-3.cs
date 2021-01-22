    public IList<T> RemoveDuplicates<T>(IEnumerable<T> elems)
    {
        IList<T> uniques = new List<T>();
        foreach(T item in elems)
           if(!uniques.Contains(item))
              uniques.Add(item);
        return uniques;
    }
