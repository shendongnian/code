    public static class IEnumerableExt {
        // TKey combineFn((TKey Key, T Value) PrevKeyItem, T curItem):
        // PrevKeyItem.Key = Previous Key
        // PrevKeyItem.Value = Previous Item
        // curItem = Current Item
        // returns new Key
        public static IEnumerable<(TKey Key, T Value)> ScanPair<T, TKey>(this IEnumerable<T> src, TKey seedKey, Func<(TKey Key, T Value), T, TKey> combineFn) {
            using (var srce = src.GetEnumerator()) {
                if (srce.MoveNext()) {
                    var prevkv = (seedKey, srce.Current);
        
                    while (srce.MoveNext()) {
                        yield return prevkv;
                        prevkv = (combineFn(prevkv, srce.Current), srce.Current);
                    }
                    yield return prevkv;
                }
            }
        }
        
        // bool testFn(T prevItem, T curItem)
        // returns groups by sequential matching bool
        public static IEnumerable<IGrouping<int, T>> GroupByWhile<T>(this IEnumerable<T> src, Func<T, T, bool> testFn) =>
            src.ScanPair(1, (kvp, cur) => testFn(kvp.Value, cur) ? kvp.Key : kvp.Key + 1)
               .GroupBy(kvp => kvp.Key, kvp => kvp.Value);
    }
