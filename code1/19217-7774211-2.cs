    public static IEnumerable<string> ParseArguments(this string commandLine)
    {
        if (string.IsNullOrWhiteSpace(commandLine))
            yield break;
        var sb = new StringBuilder();
        bool inQuote = false;
        foreach (char c in commandLine) {
            if (c == '"' && !inQuote) {
                inQuote = true;
                continue;
            }
            if (c != '"' && !(char.IsWhiteSpace(c) && !inQuote)) {
                sb.Append(c);
                continue;
            }
            if (sb.Length > 0) {
                var result = sb.ToString();
                sb.Clear();
                inQuote = false;
                yield return result;
            }
        }
        if (sb.Length > 0)
            yield return sb.ToString();
    }
