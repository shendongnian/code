    public IEnumerable<T> GetItems(Predicate<T> match)
    {
        foreach (T item in GetList())
        {
            if (match(item))
               yield return item;  
        }
    }
