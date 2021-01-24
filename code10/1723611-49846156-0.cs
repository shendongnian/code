    public static void MergeIntoFirst<T>(ICollection<T> c1, ICollection<T> c2)
    {
        if(c1==null || c2==null)
            throw new ArgumentNullException();
    
        if (c1 == c2)
            return; //if they are pointing to the same array, then we can exit.
    
        foreach (T item in c2)
        {
            if (!c1.Contains(item))
                c1.Add(item);
        }
    }
