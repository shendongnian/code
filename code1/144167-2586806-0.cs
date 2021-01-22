    using (ISession session = sessionFactory.OpenSession())
    using (ITransaction tx = session.BeginTransaction())
    {                                
         session.Save(
            new Parent() 
            {
                Children = new List<Child>() 
                { 
                    new Child(), 
                    new Child() 
                } 
            });
         tx.Commit();
    }
