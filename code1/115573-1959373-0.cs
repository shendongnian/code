    using(var session = sessionFactory.OpenSession())
    using(var tx = session.BeginTransaction())
    {
        var group = new Group {GroupName="Programmers Anonymous"};
        session.Save(group);
        tx.Commit();
    }
