    public static IEnumerable<string> ConcatenateValues(IEnumerable<int> values, string separator, int maxLength, bool skipDuplicates)
    {
        IDictionary<int, string> valueDictionary = null;
        StringBuilder sb = new StringBuilder();
        if (skipDuplicates)
        {
            valueDictionary = new Dictionary<int, string>();
        }
        foreach (int value in values)
        {
            if (skipDuplicates)
            {
                if (valueDictionary.ContainsKey(value)) continue;
                valueDictionary.Add(value, "");
            }
            string s = value.ToString(CultureInfo.InvariantCulture);
            if ((sb.Length + separator.Length + s.Length) > maxLength)
            {
                // Max length reached, yield the result and start again
                if (sb.Length > 0) yield return sb.ToString();
                sb.Length = 0;
            }
            if (sb.Length > 0) sb.Append(separator);
            sb.Append(s);
        }
        // Yield whatever's left over
        if (sb.Length > 0) yield return sb.ToString();
    }
