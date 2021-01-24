    private static void AppendSearch(StringBuilder search, string name, string value) {
        if (!string.IsNullOrEmpty(value)) {
            search.Append($"&{name}={value}");
        }
    }
