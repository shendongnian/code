    private static string CreateWhereClause(List<Filter> filters)
    {
        if (filters == null) return null;
        if (!filters.Any()) return string.Empty;
        var results = new Dictionary<string, string>();
        foreach (var filter in filters)
        {
            if (results.ContainsKey(filter.ColumnName))
            {
                results[filter.ColumnName] += $",'{filter.ColumnValue}'";
            }
            else
            {
                results.Add(filter.ColumnName, $"'{filter.ColumnValue}'");
            }
        }
        return string.Join(" AND ", results.Select(result => 
            $"{result.Key} IN ({result.Value})"));
    }
