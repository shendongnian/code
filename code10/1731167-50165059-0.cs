    public static class Ext {
        public static ArraySegment<T> Slice<T>(this T[] src, int start, int? count = null) => (count.HasValue ? new ArraySegment<T>(src, start, count.Value) : new ArraySegment<T>(src, start, src.Length - start));
        public static string Join(this IEnumerable<string> strings, string sep) => String.Join(sep, strings.ToArray());
        public static string Join(this IEnumerable<string> strings, char sep) => String.Join(sep.ToString(), strings.ToArray());
    }
