    public static class ToAnonymousExt {
        public static T ToAnonymous<T>(this T patternV, Match m) {
            var it = typeof(T).GetPropertiesOrFields();
            var cd = m.Groups.Cast<Group>().ToDictionary(g => g.Name, g => g.Value);
            return (T)Activator.CreateInstance(typeof(T), Enumerable.Range(0, it.Count).Select(n => cd[it[n].Name]).ToArray());
        }
    }
