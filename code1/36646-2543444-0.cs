    public static IEnumerable<TResult> Pairwise<T, TResult>(this IEnumerable<T> enumerable, Func<T, T, TResult> selector)
    {
        var previous = enumerable.First();
        foreach (var item in enumerable.Skip(1))
        {
            yield return selector(previous, item);
            previous = item;
        }
    }
