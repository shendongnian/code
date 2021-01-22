    using(var tx = session.BeginTransaction())
    {
        try
        {
            FooClass fc = new FooClass("value");
            nhsession.Save(fc);
            var nativeQuery = nhsession.CreateSQLQuery("some insert/update query that depends on fc's id");
            // Add parameters to nativeQuery using SetXXX methods
            nativeQuery.SetXXX(...);
            // Save nativeQuery
            nativeQuery.Save(); // I think...
            tx.Commit();
        }
        catch (...)
        {
            tx.Rollback();
        }
    }
