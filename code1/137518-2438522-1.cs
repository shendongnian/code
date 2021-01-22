    try
                        {
                            //  Now that we have our Configuration object, create a new SessionFactory
                            sessionFactory = cfg.BuildSessionFactory();
        
                            if (sessionFactory == null)
                            {
                                throw new InvalidOperationException("cfg.BuildSessionFactory() returned null.");
                            }
        
                            if (sessionFactoryConfigPath != null)
                                sessionFactories.Add(sessionFactoryConfigPath, sessionFactory);
                        }
                        catch (Exception)
                        { 
                            if (sessionFactoryConfigPath != null)
                                sessionFactory = (ISessionFactory) sessionFactories[sessionFactoryConfigPath];
                        }
