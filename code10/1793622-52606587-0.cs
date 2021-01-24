    public interface IOrmRepository
    {
        IDbConnection Connection { get; }
    }
    public class DapperRepository : IOrmRepository
    {
        private readonly IDbConnection _context;
        public DapperRepository(IDbConnection context)
        {
            _context = context;
        }
        public IDbConnection Connection
        {
            get { return _context; }
        }
    }
