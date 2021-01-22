    public static int GetUnorderedHashCode<T>(this IEnumerable<T> source)
    {
        unchecked
        {
            int sum = 0;
            int count = 0;
            foreach (T item in source)
            {
                sum = sum + item.GetHashCode();
                count++
            }
            return ((605347 + sum) * 17) + count;
        }
    }
