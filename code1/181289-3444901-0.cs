    public class SomeService
        {
            private SomeDataContext _db = null;
    
            public SomeService() 
            {
                _db = new SomeDataContext(ConfigurationManager.ConnectionStrings["SomeSqlServer"].ConnectionString);
            }
    
            public SomeService(string connectionString)
            {
                _db = new SomeDataContext(connectionString);
            }
    
            public SomeDataContext DB
            {
                get
                {
                    return _db;
                }
            }
            // whatever methods you want to use that access this DataContext
    }
