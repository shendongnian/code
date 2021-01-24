    public static class Ext {
        public static IEnumerable<(TKey Key, T Value)> ScanPair<T, TKey>(this IEnumerable<T> src, TKey seedKey, Func<(TKey Key, T Value), T, TKey> combine) {
            using (var srce = src.GetEnumerator()) {
                if (srce.MoveNext()) {
                    var prevkv = (seedKey, srce.Current);
    
                    while (srce.MoveNext()) {
                        yield return prevkv;
                        prevkv = (combine(prevkv, srce.Current), srce.Current);
                    }
                    yield return prevkv;
                }
            }
        }
        public static IEnumerable<IGrouping<int, TRes>> GroupByWhile<T, TRes>(this IEnumerable<T> src, Func<T, T, bool> test, Func<T, TRes> result) =>
            src.ScanPair(1, (kvp, cur) => test(kvp.Value, cur) ? kvp.Key : kvp.Key + 1).GroupBy(kvp => kvp.Key, kvp => result(kvp.Value));
    
        public static IEnumerable<IGrouping<int, TRes>> GroupBySequential<T, TRes>(this IEnumerable<T> src, Func<T, int> SeqNum, Func<T, TRes> result) =>
            src.GroupByWhile((prev, cur) => SeqNum(prev) + 1 == SeqNum(cur), result);
        public static IEnumerable<IGrouping<int, T>> GroupBySequential<T>(this IEnumerable<T> src, Func<T, int> SeqNum) => src.GroupBySequential(SeqNum, e => e);
    
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> src, Func<T, TKey> keyFun, IEqualityComparer<TKey> comparer = null) {
            var seenKeys = new HashSet<TKey>(comparer);
            foreach (var e in src)
                if (seenKeys.Add(keyFun(e)))
                    yield return e;
        }
    
        public static int ToInteger(this string s) => Convert.ToInt32(s);
    }
