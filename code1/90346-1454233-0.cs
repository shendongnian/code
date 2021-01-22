    var session = NHibernateSessionManager.CurrentSession;
    using(NHibernateSessionManager.CurrentSession.BeginTransaction()) {
        var foo = session.Linq<Foo>.ToList()[0];
        foo.SomeProperty = "test";
        var reloadedFoos = session.Linq<Foo>()
            .Where(x => x.SomeProperty == "test");
        Assert.That(reloadedFoos.Count > 0);
    }
