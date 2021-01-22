       public void Add(Login login)
       {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                 Add(login, session);
            }
       }
       public void Add(Login login, ISession session)
       {
            //no longer need to create a session here - it is passed in
            //using (ISession session = NHibernateHelper.OpenSession()) 
            
            ...Add using the session
       }
