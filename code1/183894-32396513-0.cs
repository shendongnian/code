    public static string GetSubstring(this string source, int length, params string[] options)
        {
            if (string.IsNullOrWhiteSpace(source))
            {
                return string.Empty;
            }
            if (source.Length <= length)
            {
                return source;
            }
            var indices =
                options.Select(
                    separator => source.IndexOf(separator, length, StringComparison.CurrentCultureIgnoreCase))
                    .Where(index => index >= 0)
                    .ToList();
            if (indices.Count > 0)
            {
                return source.Substring(0, indices.Min());
            }
            return source;
        }
