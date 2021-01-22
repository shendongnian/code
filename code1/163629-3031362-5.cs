    public static int GetUnorderedHashCode<T>(this IEnumerable<T> source)
    {
        unchecked
        {
            int sum = 907;
            int count = 953;
            foreach (T item in source)
            {
                sum = sum + item.GetHashCode();
                count++
            }
            return 991 * sum * count;
        }
    }
