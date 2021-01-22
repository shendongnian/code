    class Configuration:IRepositoryConfiguration,IMailConfiguration
    {
        private string connectionString;
        //IRepository configurations
        public string ConnectionString
        {
            //read connection string from somewhere
            get { return connectionString; }
        }
        //EMail configurations
        public string Smtp
        {
            get { return smpt; }
        }
        
    }
   
    interface IRepositoryConfiguration
    {
        string ConnectionString { get;}
    }
 
    public abstract class Repository
        {
            public Repository(IRepositoryConfiguration configuration)
            {
                _connectionString = configuration.ConnectionString;
            }
    
            public virtual string ConnectionString
            {
                get { return _connectionString; }
            }
            private readonly string _connectionString;
        }
