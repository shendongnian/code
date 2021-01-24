    private List<int> GetListFromIDS<T>(string ids, IEnumerable<T> data, Func<T, int> selectExpression)
    {
        if (string.IsNullOrEmpty(ids))
            return null;
    
        var list = ids
            .Split(',') // simplify
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => int.Parse(x.Trim()));
    
        return data
            .Where(x => list.Contains(selectExpression(x)))
            .Select(selectExpression)
            .ToList();
    }
