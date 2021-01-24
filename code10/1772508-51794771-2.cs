    public static class IEnumerableIntExt {
        public static IEnumerable<KeyValuePair<int, int>> MostCommon(this IEnumerable<int> src) {
            var mysrc = new List<int>(src);
            mysrc.Sort();
            var maxc = 0;
            var maxmodes = new List<int>();
            foreach (var g in mysrc.GroupByRuns()) {
                var gc = g.Count();
    
                if (gc > maxc) {
                    maxmodes.Clear();
                    maxmodes.Add(g.Key);
                    maxc = gc;
                }
                else if (gc == maxc)
                    maxmodes.Add(g.Key);
            }
    
            return maxmodes.Select(m => new KeyValuePair<int, int>(m, maxc));
        }
    }
