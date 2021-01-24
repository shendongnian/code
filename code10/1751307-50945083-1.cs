	internal sealed class NHSessionFactoryInternal
	{
		ISessionFactory sessionFactory;
		internal ISessionFactory SessionFactory { get { return sessionFactory; } }
		internal void CreateSessionFactory(Configuration nhConfiguration)
		{
			if(sessionFactory != null)
				throw new NHWrapperException("SessionFactory is already created.");
			try
			{
				sessionFactory = nhConfiguration.BuildSessionFactory();
			}
			catch(Exception exception)
			{
				throw new NHWrapperException("Failed to build session factory.", exception);
			}
		}
		internal INHSession CreateNHSession(bool readOnly = false)
		{
			if(sessionFactory == null)
				throw new NHWrapperException("Session factory is not build.");
			return new NHSession(sessionFactory.OpenSession(), NHSettings.DefaultFlushMode, readOnly);
		}
		internal void CloseSessionFactory()
		{
			if(sessionFactory == null)
				return;
			if(sessionFactory.IsClosed == false)
				sessionFactory.Close();
			sessionFactory.Dispose();
			sessionFactory = null;
		}
	}
