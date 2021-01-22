    [TestMethod]
    public void QueryComplexityTest()
    {
        var users = _dataContext.Users;
        Func<User, bool>                funcSelector =       q => q.UserName.StartsWith("Test");
        Expression<Func<User, bool>>    expressionSelector = q => q.UserName.StartsWith("Test");
        // Returns IEnumerable, and do filtering of data on client-side
        IQueryable<User> func = users.Where(funcSelector).AsQueryable();
        // Returns IQuerible and do filtering of data on server side
        // SELECT ... FROM [dbo].[User] AS [t0] WHERE [t0].[user_name] LIKE @p0
        IQueryable<User> exp = users.Where(expressionSelector);
    }
