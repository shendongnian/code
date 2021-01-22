    public static IEnumerable<T> EverySecondObject<T>(this IEnumerable<T> list)
    {
        using (var enumerator = list.GetEnumerator())
        {
            while (true)
            {
                if (!enumerator.MoveNext())
                    yield break;
                if (enumerator.MoveNext())
                    yield return enumerator.Current;
                else
                    yield break;
            }
        }
    }
