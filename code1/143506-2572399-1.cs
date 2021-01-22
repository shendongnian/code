        public ISession GetContextSession()
        {
            var factory = GetFactory(); // GetFactory returns an ISessionFactory in my helper class
            ISession session;
            if (CurrentSessionContext.HasBind(factory))
            {
                session = factory.GetCurrentSession();
            }
            else
            {
                session = factory.OpenSession();
                CurrentSessionContext.Bind(session);
            }
            return session;
        }
        public void EndContextSession()
        {
            var factory = GetFactory();
            var session = CurrentSessionContext.Unbind(factory);
            if (session != null && session.IsOpen)
            {
                try
                {
                    if (session.Transaction != null && session.Transaction.IsActive)
                    {
                        session.Transaction.Rollback();
                        throw new Exception("Rolling back uncommited NHibernate transaction.");
                    }
                    session.Flush();
                }
                catch (Exception ex)
                {
                    log.Error("SessionKey.EndContextSession", ex);
                    throw;
                }
                finally
                {
                    session.Close();
                    session.Dispose();
                }
            }
        }        
