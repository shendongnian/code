    public static IEnumerable<TResult> Scan<T,TResult>(this IEnumerable<T> src, Func<T, T, TResult> combine) {
        var srce = src.GetEnumerator();
        if (srce.MoveNext()) {
            T prev = srce.Current;
            while (srce.MoveNext()) {
                yield return combine(prev, srce.Current);
                prev = srce.Current;
            }
        }
    }
