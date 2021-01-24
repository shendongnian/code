    public static Dictionary<string, string> GetNameValuePairs(string source)
    {
        return source?.Split('\n')
            .Select(i => i.Split(':'))
            .ToDictionary(k => k[0].Trim(), v => v.Length > 1 ? v[1].Trim() : null,
                StringComparer.OrdinalIgnoreCase);
    }
