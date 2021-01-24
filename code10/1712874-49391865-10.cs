    private List<int> GetListFromIDS<T>(string ids, IEnumerable<T> data, Func<T, IEnumerable<int>, bool> filterExpression, Func<T, int> selectExpression)
    {
        if (string.IsNullOrEmpty(ids))
            return null;
    
        var list = ids
            .Split(',') // simplify
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => int.Parse(x.Trim()));
    
        return data
            .Where(x => filterExpression(x, list))
            .Select(selectExpression)
            .ToList();
    }
