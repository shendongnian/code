    public class NhibernateSessionFactory : INhibernateSessionFactory
    {
        private static ISessionFactory _sessionFactory;
        private static Mutex _mutex = new Mutex();  // <-- Added
        public ISession OpenSession()
        {
            if (_sessionFactory == null)
            {
                _mutex.WaitOne();              // <-- Added
                if (_sessionFactory == null)   // <-- Added
                {                              // <-- Added
                    var cfg = Fluently.Configure().
                        Database(SQLiteConfiguration.Standard.ShowSql().UsingFile("Foo.db")).
                        Mappings(m => m.FluentMappings.AddFromAssemblyOf<MappingsPersistenceModel>());
                    _sessionFactory = cfg.BuildSessionFactory();
                    BuildSchema(cfg);
                }                              // <-- Added
                _mutex.ReleaseMutex();         // <-- Added
            }
            return _sessionFactory.OpenSession();
        }
        private static void BuildSchema(FluentConfiguration configuration)
        {
            var sessionSource = new SessionSource(configuration);
            var session = sessionSource.CreateSession();
            sessionSource.BuildSchema(session);            
        }
    }
