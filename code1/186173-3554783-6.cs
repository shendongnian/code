        public void Add(User user)
        {
            using (ISession session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    IEnumerable<UserRole> userRoles = user.UserRoles;
                    user.UserRoles = null;
                    session.Save(user);
                    foreach (UserRole userRole in userRoles)
                    {
                        userRole.UserID = user.UserID;
                        session.Save(userRole);
                    }
                    transaction.Commit();
                }
            }
        }
