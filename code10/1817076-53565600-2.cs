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
    }
