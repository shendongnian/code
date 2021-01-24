    public class UnitOfWork : IUnitOfWork {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private IUserRepository _user;
        private IRoleRepository _role;
        private bool _disposed;
        private bool _token;
        public UnitOfWork(IDbConnectionFactory factory) {
            _connection = factory.CreateConnection();
            _connection.Open();
            _transaction = _connection.BeginTransaction();
            _token = false;
        }
        //Remove the rest of the code for brevity
    }
