    public static class Ext {
        public static int[] Add(this int[] v1, int[] v2) => v1.Zip(v2, (v1v, v2v) => v1v+v2v).ToArray();
        public static int[][] Add(this int[][] a1, int[][] a2) => a1.Zip(a2, (a1r, a2r) => a1r.Add(a2r)).ToArray();
        public static TSource Reduce<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func) => source.Aggregate(func);
        public static IEnumerable<T> Reduce2<T>(this IEnumerable<IEnumerable<T>> src, Func<T, T, T> op) => src.Select(s => s.Reduce(op));
    }
