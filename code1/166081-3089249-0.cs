    using (var session = sessionFactory.OpenSession())
    using (var tx = session.BeginTransaction())
    {
        var items = session.CreateQuery("select something complex from a big table")
                           .SetTimeout(600) // 10 minutes
                           .List();
        tx.Commit();
    }
