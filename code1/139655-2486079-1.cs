    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> items,
        Predicate<T> splitCondition)
    {
        using (IEnumerator<T> enumerator = items.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                yield return GetNextItems(enumerator, splitCondition).ToArray();
            }
        }
    }
    private static IEnumerable<T> GetNextItems<T>(IEnumerator<T> enumerator,
        Predicate<T> stopCondition)
    {
        do
        {
            T item = enumerator.Current;
            if (stopCondition(item))
            {
                yield break;
            }
            yield return item;
        } while (enumerator.MoveNext());
    }
