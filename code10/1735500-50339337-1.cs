    public static class IEnumerableExt {
        public static T FirstOrDefault<T>(this IEnumerable<T> src, Func<T, bool> testFn, T defval) => src.Where(aT => testFn(aT)).DefaultIfEmpty(defval).First();
    }
    public static class StringExt {
        public static int IndexOf(this string source, string match, StringComparer sc) {
            return Enumerable.Range(0, source.Length) // for each position in the string
                             .FirstOrDefault(i => // find the first position where either
                                 // match is Equals at this position for length of match (or to end of string) or
                                 sc.Equals(source.Substring(i, Math.Min(match.Length, source.Length-i)), match) ||
                                 // match is Equals to on of the substrings beginning at this position
                                 Enumerable.Range(1, source.Length-i-1).Any(ml => sc.Equals(source.Substring(i, ml), match)),
                                 -1 // else return -1 if no position matches
                              );
        }
    }
