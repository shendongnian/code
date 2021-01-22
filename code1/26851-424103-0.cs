    using(var session = TheSessionFactory.OpenSession()) {
        using(var txn = session.BeginTransaction()) {
            //transactional work
            txn.Commit();
        }
    }
