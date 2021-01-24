	public sealed class NHSessionFactory
	{
		/*
		 * This must be instance class.
		 * New instance should be created for each Database Schema.
		 * Maintain the instance in calling application.
		 * This is useful if multiple databases are used in one application.
		*/
		NHSessionFactoryInternal nhSessionFactoryInternal = null;
		public void Start(NHSessionFactoryStartParams startParams)
		{
			Configuration nhConfiguration;
			nhConfiguration = new Configuration();
			nhConfiguration.SetProperty(NHibernate.Cfg.Environment.Dialect, startParams.Dialect);
			nhConfiguration.SetProperty(NHibernate.Cfg.Environment.ConnectionString, startParams.ConnectionString);
			if(string.IsNullOrEmpty(startParams.DefaultSchema) == false)
				nhConfiguration.SetProperty(NHibernate.Cfg.Environment.DefaultSchema, startParams.DefaultSchema);
			nhConfiguration.SetProperty(NHibernate.Cfg.Environment.Isolation, "ReadCommitted");
			nhConfiguration.SetProperty(NHibernate.Cfg.Environment.BatchSize, NHSettings.DefaultBatchSize.ToString());
			if(string.IsNullOrEmpty(startParams.LogFilePath) == false)
			{
				nhConfiguration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "true");
				nhConfiguration.SetProperty(NHibernate.Cfg.Environment.FormatSql, "true");
			}
			else
			{
				nhConfiguration.SetProperty(NHibernate.Cfg.Environment.ShowSql, "false");
				nhConfiguration.SetProperty(NHibernate.Cfg.Environment.FormatSql, "false");
			}
			nhConfiguration.AddMapping(startParams.HbmMappingInstance);
			try
			{
				nhSessionFactoryInternal = new NHSessionFactoryInternal();
				nhSessionFactoryInternal.CreateSessionFactory(nhConfiguration);
			}
			catch(Exception exception)
			{
				Stop();
				throw new NHWrapperException("Failed to create session factory.", exception);
			}
		}
		public void Stop()
		{
			if(nhSessionFactoryInternal == null)
				return;
			nhSessionFactoryInternal.CloseSessionFactory();
			nhSessionFactoryInternal = null;
		}
		public INHSession CreateSession(bool readOnly)
		{
			if(nhSessionFactoryInternal == null)
				throw new NHWrapperException("NHWrapper is not started.");
			return nhSessionFactoryInternal.CreateNHSession(readOnly);
		}
	}
