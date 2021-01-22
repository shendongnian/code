    NHibernateManager<User> manager = new NHibernateManager<User>();
    User name = manager.ReadFirst();
    
    // All items filtered (using OR)
    IList<User> list = manager.OrList("@Name", "12345", "@Name", "54321");
    
    // Paged
    list = manager.Page(1,10);
