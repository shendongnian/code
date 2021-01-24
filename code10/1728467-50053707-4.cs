    public static class ReplaceExt {
        public static Dictionary<string, string> CaptureDictionaryFrom(this string src, string pat) => Regex.Match(src, pat).ToCaptureDictionary();
        public static Dictionary<string, string> ToCaptureDictionary(this Match m) => m.Groups.Cast<Group>().ToDictionary(g => g.Name, g => g.Value);
        public static string Expand(this string src, Dictionary<string, string> vals) => Regex.Replace(src, @"\$(?:(?<var>\d+)|{(?<var>\w+)})", m => vals.TryGetValue(m.Groups[1].Value, out var v) ? v : m.Value);
        public static string ExpandReplace(this string src, string pat, string sub, Dictionary<string, string> vals) => Regex.Replace(src, pat, m => sub.Expand(m.ToCaptureDictionary()).Expand(vals));
    }
