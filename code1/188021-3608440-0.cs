    public IList<T> GetPageOf<T>(int page, int pageSize, Func<ICriteria,ICriteria> modifier)
    {
        return Session.CreateCriteria<T>()
               .SetFirstResult(pageSize * (page-1))
               .SetMaxResults(pageSize)
               .ToList<T>();
    }
