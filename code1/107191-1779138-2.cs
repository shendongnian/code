    public static IEnumerable<T> TakeAllButLast<T>(this IEnumerable<T> source)
    {
        using (var enumerator = source.GetEnumerator())
            bool first = true;
            T prev;
            while(enumerator.MoveNext())
            {
                if (!first)
                    yield return prev;
                first = false;
                prev = enumerator.Current;
            }
        }
    }
