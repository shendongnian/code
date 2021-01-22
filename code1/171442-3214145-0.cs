    public Site GetSiteByHost(string host)
    {
        return _session
            .CreateCriteria<Site>()
            .Add(SqlExpression.Like<Site>(g => g.URLName, host))
            .List<Site>()
            .FirstOrDefault();
    }
