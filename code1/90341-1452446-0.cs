    using(var session = NHibernateSessionManager.CurrentSession)
    {
      using(var transaction = session.BeginTransaction())
      {
        var foo = session.Linq<Foo>.ToList()[0];
    
        foo.SomeProperty = "test";
    
        session.SaveOrUpdate(foo);
        transaction.Commit();
      }
    }
