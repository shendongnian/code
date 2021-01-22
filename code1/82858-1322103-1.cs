    static readonly Regex rePattern = new Regex(
        @"\{([^\}]+)\}", RegexOptions.Compiled);
    static string Format<T>(string pattern, T template) {
        Dictionary<string, string> cache = new Dictionary<string, string>();
        return rePattern.Replace(pattern, match => {
            string key = match.Groups[1].Value;
            string value;
            
            if (!cache.TryGetValue(key, out value)) {
                var prop = typeof(T).GetProperty(key);
                if (prop == null) {
                    throw new ArgumentException("Not found: " + key, "pattern");
                }
                value = Convert.ToString(prop.GetValue(template, null));
                cache.Add(key, value);
            }
            return value;
        });
    }
  
