    public static class IEnumerableExt {
        public static (int Count, int Min, int Max, double Average) Stats(this IEnumerable<int> src) {
            var a = src.Aggregate((Count: 0, Min: Int32.MaxValue, Max: Int32.MinValue, Sum: 0),
                                  (g, v) => (g.Count + 1, v < g.Min ? v : g.Min, v > g.Max ? v : g.Max, g.Sum + v));
            return (a.Count, a.Min, a.Max, a.Sum / (double)(a.Count == 0 ? 1 : a.Count));
        }
    }
