    if (
        sessionFactoryConfigPath != null && 
        sessionFactories.ContainsKey(sessionFactoryConfigPath)
    ) {
        sessionFactory = cfg.BuildSessionFactory();
    
        if (sessionFactory == null)
        {
            throw new InvalidOperationException("cfg.BuildSessionFactory() returned null.");
        }
    
        sessionFactories.Add(sessionFactoryConfigPath, sessionFactory);
    }
