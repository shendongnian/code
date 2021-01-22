    public IEnumerable<Post> GetPosts(object threadID, int pageSize, int index, out totalPosts) 
    {
        var results = session
            .CreateMultiCriteria()
            .Add(GetCriteria(threadID)
                 .SetFirstResult((index - 1) * pageSize)
                 .SetMaxResults(pageSize)
            )
            .Add(GetCriteria(threadID)
                 .SetProjection(Projections.RowCount())
            )
            .List();
        var counts = (IList)results[1];
        totalPosts = (int)counts[0];
        return ((IList)results[0]).Cast<Post>();
    }
    private DetachedCriteria GetCriteria(object threadID)
    {
        return DetachedCriteria
            .For<Post>()
            .Add(Expression.Eq("Thread.Id", threadID));
    }
