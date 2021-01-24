    public static IEnumerable<string> MySpecialSplit(string value, string separator, string escapeStart, string escapeEnd)
    {
        var result = new List<string>();
        var start = value.StartsWith(separator) ? separator.Length : 0;
        var inEscape = false;
        for (var i = start; i < value.Length - separator.Length; i++)
        {
            if (inEscape && value.Length > i + escapeEnd.Length && value.Substring(i, escapeEnd.Length).Equals(escapeEnd))
            {
                inEscape = false;
            }
            else if (!inEscape && value.Length > i + escapeStart.Length && value.Substring(i, escapeStart.Length).Equals(escapeStart))
            {
                inEscape = true;
            }
            if (!inEscape && value.Substring(i, separator.Length).Equals(separator))
            {
                result.Add(value.Substring(start, i - start));
                i += separator.Length;
                start = i;
                i--;
            }
        }
        if (start < value.Length - separator.Length)
        {
            var rest = value.Substring(start);
            if (rest.EndsWith(separator))
            {
                rest = rest.Substring(0, rest.Length - separator.Length);
            }
            result.Add(rest);
        }
        return result;
    }
