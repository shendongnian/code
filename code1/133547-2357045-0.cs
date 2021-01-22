    public interface ICustomDataContextFactory
    {
        CustomDataContext Create();
    }
    public class CustomDataContextFactory : ICustomDataContextFactory
    {
        private readonly string _connectionStringName;
        public CustomDataContextFactory(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }
        public CustomDataContext Create()
        {
            var connectionString = ConfigurationManager.ConnectionStrings[_connectionStringName].ConnectionString;
            return new CustomDataContext(connectionString);
        }
    }
