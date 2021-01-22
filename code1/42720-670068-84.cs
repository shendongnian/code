    public static int GetOrderIndependentHashCode<T>(IEnumerable<T> source)
    {
        int hash = 17;
        foreach (T element in source)
        {
            int h = EqualityComparer<T>.Default.GetHashCode(element);
            if (h != 0)
                hash = unchecked (hash * h);
        }
        return hash;
    }
