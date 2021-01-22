    public static IEnumerable<Tuple<T, T>> ConsecutivePairs<T>(this IEnumerable<T> sequence)
    {
        // Omitted nullity checking; would need an extra method to cope with
        // iterator block deferred execution
        using (IEnumerator<T> iterator = sequence.GetEnumerator())
        {
            if (!iterator.MoveNext())
            {
                yield break;
            }
            T previous = iterator.Current;
            while (iterator.MoveNext())
            {
                yield return Tuple.Create(previous, iterator.Current);
                previous = iterator.Current;
            }
        }
    }
