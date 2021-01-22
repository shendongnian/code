    var session = SessionFactory.OpenSession;
    var transaction = session.BeginTransaction;
    var query = session.CreateQuery("FROM Customer c WHERE c.LastName = :LastName And c.FirstName = :FirstName");
    query.SetString("FirstName", FirstName);
    query.SetString("LastName", LastName);
    var returnList = _Query.List(Of Customer)();
    transaction.Commit();
