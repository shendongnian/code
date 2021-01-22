    public static int Count(this IEnumerable sequence)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException("sequence");
        }
        // Optimisation: won't optimise for collections which
        // implement ICollection<T> but not ICollection, admittedly.
        ICollection collection = sequence as ICollection;
        if (collection != null)
        {
            return collection.Count;
        }
        IEnumerator iterator = sequence.GetEnumerator();
        try
        {
            int count = 0;
            while (iterator.MoveNext())
            {
                // Don't bother accessing Current - that might box
                // a value, and we don't need it anyway
                count++;
            }
            return count;
        }
        finally
        {
            IDisposable disposable = iterator as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
        }
    }
