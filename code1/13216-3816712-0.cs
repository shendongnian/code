    private Expression<T> GetExpression<T>(Expression<T> e)
    {
        return e;
    }
    [TestMethod]
    public void QueryComplexityTest()
    {
        var users = _dataContext.Users;
        var funcSelector = new Func<User, bool>(q => q.UserName.StartsWith("Test"));
        var expressionSelector = GetExpression<Func<User, bool>>(q => q.UserName.StartsWith("Test"));
        // Returns IEnumerable, and do filtering of data on client-side
        IEnumerable<User> func = users.Where(funcSelector);
        // Returns IQuerible and do filtering of data on server side
        // SELECT ... FROM [dbo].[User] AS [t0] WHERE [t0].[user_name] LIKE @p0
        IQueryable<User> exp = users.Where(expressionSelector);
    }
