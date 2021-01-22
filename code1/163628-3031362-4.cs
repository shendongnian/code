    public static int GetOrderedHashCode<T>(this IEnumerable<T> source)
    {
        unchecked
        {
            int hash = 269;
            foreach (T item in source)
            {
                hash = (hash * 17) + item.GetHashCode;
            }
            return hash;
        }
    }
