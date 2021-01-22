    public static IEnumerable<IEnumerable<T>> Slices<T>(this IEnumerable<T> items, int size)
    {
        using (StickyEnumerable<T> sticky = new StickyEnumerable<T>(items))
        {
            IEnumerable<T> slice;
            do
            {
                slice = sticky.Take(size).ToList();
                yield return slice;
            } while (slice.Count() == size);
        }
        yield break;
    }
