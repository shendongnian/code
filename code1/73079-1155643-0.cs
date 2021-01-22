    public static int Count(this IEnumerable enumerable)
    {
        int count = 0;
        foreach(object item in enumerable)
        {
            count++;
        }
        return count;
    }
