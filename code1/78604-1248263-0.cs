    public static Predicate<T> Or<T>(params Predicate<T>[] predicates)
    {
        return delegate (T item)
        {
            foreach (Predicate<T> predicate in predicates)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        };
    }
