    public static IEnumerable<TResult> ScanByPairs<T, TResult>(this IEnumerable<T> src, Func<T, T, TResult> combineFn) {
        using (var srce = src.GetEnumerator()) {
            if (srce.MoveNext()) {
                var prev = srce.Current;
                while (srce.MoveNext()) {
                    yield return combineFn(prev, srce.Current);
                    prev = srce.Current;
                }
            }
        }
    }
