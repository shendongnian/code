    public static IEnumerable<T> MoveUp<T>(this IEnumerable<T> enumerable, int itemIndex)
    {
        int i = 0;
        IEnumerator<T> enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext())
        {
            i++;
            if (itemIndex.Equals(i))
            {
                T previous = enumerator.Current;
                if (enumerator.MoveNext())
                {
                    yield return enumerator.Current;
                }
                yield return previous;
                break;
            }
            yield return enumerator.Current;
        }
        while (enumerator.MoveNext())
        {
            yield return enumerator.Current;
        }
    }
