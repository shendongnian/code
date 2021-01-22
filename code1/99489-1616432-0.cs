    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> input, int size)
    {
        return input.Select((a, i) => new { Item = a, Index = i })
                    .GroupBy( b => (b.Index / size))
                    .Select(c => c.Select(d => d.Item));
    }
