    public static class IEnumerableExt {
        public static IEnumerable<(TKey Key, T Value)> ScanPair<T, TKey>(this IEnumerable<T> src, Func<T, TKey> seedFn, Func<(TKey Key, T Value), T, TKey> combineFn) {
            using (var srce = src.GetEnumerator()) {
                if (srce.MoveNext()) {
                    var seed = (seedFn(srce.Current), srce.Current);
    
                    while (srce.MoveNext()) {
                        yield return seed;
                        seed = (combineFn(seed, srce.Current), srce.Current);
                    }
                    yield return seed;
                }
            }
        }
    }
