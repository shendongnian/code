    public static class IEnumerableExt {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source) => new HashSet<T>(source);
        public static IEnumerable<T> Leave<T>(this ICollection<T> src, int drop) => src.Take(src.Count - drop);
        public static IEnumerable<T> Drop<T>(this ICollection<T> src, int drop) => (drop < 0) ? src.Leave(-drop) : src.Skip(drop);
    }
    
    public static class StringExt {
        public static string UpTo(this string s, Regex stopRE) {
            var m = stopRE.Match(s);
            if (m.Success)
                return s.Substring(0, m.Index);
            else
                return s;
        }
    
        public static string Join(this IEnumerable<string> strings, string sep) => String.Join(sep, strings.ToArray());
        public static bool EndsWithOneOf(this string s, params string[] endings) => endings.Any(e => s.EndsWith(e));
    }
