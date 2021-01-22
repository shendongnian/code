    public IQueryable<T> SelectWithLimit<T>(int maxResults) where T : class
        {
            ICriteria criteria = SessionWrapper.Session.CreateCriteria(typeof (T)).SetMaxResults(maxResults);
            return criteria.List<T>().AsQueryable();
        }
