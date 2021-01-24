    public class UnitOfWork : IDisposable
    {
        public IOrderRepository Orders { get; }
        public ICallRepository OutCalls { get; }
        public ILoginRepository Login { get; }
    
        private readonly DataContext _context;
    
    
        public UnitOfWork(string connectionString)
        {
            _context = new DataContext(new SqlConnection());
    
            using (new Impersonation("domain", "user", "password"))
                _context.Connection.ConnectionString = connectionString;
    
            Orders = new OrderRepository(_context);
            OutCalls = new CallRepository(_context);
            Login = new LoginRepository(_context);
        }
    
        public void Dispose()
        {
            Dispose(true);
        }
    
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                    _context.Dispose();
            }
        }
    }
