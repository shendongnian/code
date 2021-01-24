    public static class IEnumerableExt {
        public static T FirstOrDefault<T>(this IEnumerable<T> src, Func<T, bool> testFn, T defval) => src.Where(aT => testFn(aT)).DefaultIfEmpty(defval).First();
    }
    public static class StringExt {
        public static int IndexOf(this string source, string match, StringComparer sc) {
            return Enumerable.Range(0, source.Length)
                             .FirstOrDefault(i =>
                                 sc.Equals(source.Substring(i, Math.Min(match.Length, source.Length-i)), match) ||
                                 Enumerable.Range(1, source.Length-i-1).Any(ml => sc.Equals(source.Substring(i, ml), match)),
                                 -1
                              );
        }
    }
