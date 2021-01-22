        public void Add(User user)
        {
            using (NHibernateHelper.OpenSession())
            {
            ...
            }
        }
       public void Add(Login login)
       {
            using (NHibernateHelper.OpenSession())
            {
            ...
            }
       }
