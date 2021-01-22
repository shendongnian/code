    public static T Sum<T>(this IEnumerable<T> source)
    {
        T sum = Operator<T>.Zero;
        foreach (T value in source)
        {
            if (value != null)
            {
                sum = Operator.Add(sum, value);
            }
        }
        return sum;
    }
