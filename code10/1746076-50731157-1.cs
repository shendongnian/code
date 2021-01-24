    public static class IEnumerableExt {
        public static int DistanceToUnique<T>(this IEnumerable<T> src, int n, IEqualityComparer<T> cmp = null) {
            var hs = new HashSet<T>(cmp ?? EqualityComparer<T>.Default);
            var pos = 0;
            using (var e = src.GetEnumerator()) {
                while (e.MoveNext()) {
                    ++pos;
                    hs.Add(e.Current);
                    if (hs.Count == n)
                        return pos;
                }
            }
            return -1;
        }
    }
