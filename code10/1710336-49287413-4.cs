    public static IEnumerable<(TKey Key, T Value)> ScanPair<T, TKey>(this IEnumerable<T> src, Func<T, TKey> fnSeed, Func<(TKey Key, T Value), T, TKey> combine) {
        using (var srce = src.GetEnumerator()) {
            if (srce.MoveNext()) {
                var seed = (fnSeed(srce.Current), srce.Current);
                while (srce.MoveNext()) {
                    yield return seed;
                    seed = (combine(seed, srce.Current), srce.Current);
                }
                yield return seed;
            }
        }
    }
