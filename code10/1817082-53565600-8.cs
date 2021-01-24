    public static class MatchExt {
        public static T MakeObjectFromGroups<T>(this Match m) where T : new() {
            var members = typeof(T).GetPropertiesOrFields().ToDictionary(pf => pf.Name.ToLower());
            var ans = new T();
            foreach (Group g in m.Groups) {
                if (members.TryGetValue(g.Name.ToLower(), out var mi))
                    mi.SetValue(ans, g.Value);
            }
    
            return ans;
        }
        public static string[] MakeArrayFromGroupValues(this Match m) {
            var ans = new string[m.Groups.Count-1];
            for (int j1 = 1; j1 < m.Groups.Count; ++j1)
                ans[j1-1] = m.Groups[j1].Value;
    
            return ans;
        }
    }
