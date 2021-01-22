    var query = DetachedCriteria.For<...>();
    
    using (var session = ...)
    using (var transaction = session.BeginTransaction())
    {
        query.GetExecutableCriteria(session)
        transaction.Commit();
    }
