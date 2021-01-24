    public static class IEnumerableExt {
        public static (int Cond1Count, int Cond2Count) Count2Chained<T>(this IEnumerable<T> src, Func<T, bool> cond1, Func<T, bool> cond2) {
            int cond1Count = 0;
            int cond2Count = 0;
            foreach (var s in src) {
                if (cond1(s)) {
                    ++cond1Count;
                    if (cond2(s))
                        ++cond2Count;
                }
            }
            return (cond1Count, cond2Count);
        }
    }
