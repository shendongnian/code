    private List<int> GetListFromIDS<T>(string ids, IEnumerable<T> data, Func<T, int> selectExpression)
    {
        if (string.IsNullOrEmpty(ids))
            return null;
    
        var list = ids
            .Split(new char[] { ',' })
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => int.Parse(x.Trim()));
    
        return data
            .Where(x => list.Any(selectExpression))
            .Select(selectExpression)
            .ToList();
    }
