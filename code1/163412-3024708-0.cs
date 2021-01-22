    using (var ts = new TransactionScope())
    using (var session1 = sessionFactory1.OpenSession())
    using (var tx1 = session1.BeginTransaction())
    using (var session2 = sessionFactory2.OpenSession())
    using (var tx2 = session2.BeginTransaction())
    {
        //Do work...
        tx1.Commit();
        tx2.Commit();
        ts.Complete();
    }
