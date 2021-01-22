    private IEnumerable<Item> FilterList(IEnumerable<Item> list, string query)
    {
        string pattern = QueryToRegex(query);
        return list.Where(i => Regex.IsMatch(i.Name, pattern, RegexOptions.Singleline));
    }
    private static string QueryToRegex(string query)
    {
        return Regex.Escape(query).Replace("\\*", ".*").Replace("\\?", ".");
    }
