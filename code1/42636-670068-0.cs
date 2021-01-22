    public static int GetOrderIndependentHashCode<T>(IEnumerable<T> source)
    {
        int hash = 0;
        foreach (T element in source)
        {
            hash = hash ^ element.GetHashCode();
        }
        return hash;
    }
