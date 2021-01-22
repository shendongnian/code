    var session = NHibernateSessionManager.CurrentSession;
    var foo = session.Linq<Foo>.ToList()[0];
    foo.SomeProperty = "test";
    
    session.Flush();
    
    var reloadedFoos = session.Linq<Foo>
                             .Where(x => x.SomeProperty == "test");
    Assert.That(reloadedFoos.Count > 0);
