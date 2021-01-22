    using(var session = NHibernateSessionManager.CurrentSession)
    {
      using(var tx = session.BeginTransaction())
      {
    	var foo = session.Linq<Foo>.ToList()[0];
    	foo.SomeProperty = "test";
    	session.SaveOrUpdate(foo);	
        tx.Commit();
      }
    }
    
    //create a new session here, the code depend if you use RhinoCommons (like me), no Rhino
    
    using(var session = NHibernateSessionManager.CurrentSession)
    {
      using(var tx = session.BeginTransaction())
      {
    	var reloadedFoos = session.Linq<Foo>
    			.Where(x => x.SomeProperty == "test");
    	Assert.That(reloadedFoos.Count > 0);
        tx.Commit();
      }
    }
