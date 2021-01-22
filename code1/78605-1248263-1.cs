    public static Predicate<T> And<T>(params Predicate<T>[] predicates)
    {
        return delegate (T item)
        {
            foreach (Predicate<T> predicate in predicates)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }
            return true;
        };
    }
