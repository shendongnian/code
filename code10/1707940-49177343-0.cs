    public static string GetUniqueName<T>(this IQueryable<T> query,
        Expression<Func<T, string>> nameSelector, string prefix)
    {
        var lastName = query.Select(nameSelector)
            .Where(x => x.StartsWith(prefix))
            .OrderByDescending(x => x.Length)
            .ThenByDescending(x => x)
            .FirstOrDefault();
    
        return prefix + (GetCounter(lastName) + 1);
    }
    
    public static int GetCounter(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return 0;
        }
        // Implement the retrieval of the counter from the name
        throw new NotImplementedException();
    }
