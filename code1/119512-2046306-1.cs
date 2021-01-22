    public class Service
    {
        public Service(IDbConnection connection, IIdentity identity)
        {
            this.Connection = connection;
            this.Identity = identity;
        }
        public void DoSomething()
        {
            // Do something with Connection and Identity properties
        }
        protected IDbConnection Connection { get; private set; }
        protected IIdentity Identity { get; private set; }
    }
