    public static class DbCommandAdapterPool
    {
        private static ConcurrentBag<DbCommandAdapter> _pool = new ConcurrentBag<DbCommandAdapter>();
        public static DbCommandAdapter SubscribeAdapter(MyContext context)
        {
            var adapter = _pool.FirstOrDefault(a => a.IsAvailable);
            if (adapter == null)
            {
                adapter = new DbCommandAdapter(context);
                _pool.Add(adapter);
            }
            else adapter.Reuse(context);
            return adapter;
        }
    }
    public class MyContext : DbContext
    {
        private readonly HReCommandAdapter _adapter;
        public MyContext(DbContextOptions options) : base(options)
        {
            //_adapter = new DbCommandAdapter();
            //var listener = this.GetService<DiagnosticSource>();
            //(listener as DiagnosticListener).SubscribeWithAdapter(_adapter);
            DbCommandAdapterPool.SubscribeAdapter(this);
        }
        public override void Dispose()
        {
            _adapter.Dispose();
            base.Dispose();
        }
        //DbSets and stuff
    }
    public class DbCommandAdapter : IDisposable
    {
        private bool _hasExecuted = false;
        private Guid? _lastExecId = null;
        private MyContext _context;
        private DiagnosticListener _listener;//added for correlation
        public bool IsAvailable { get; } = false;//Not sure what constitutes a complete transaction.
        public DbCommandAdapter(MyContext context)
        {
            this._context = context;
            this._listener = context.GetService<DiagnosticSource>();
        }
        
        ...
        public void Reuse(MyContext context)
        {
            this.IsAvailable = false;
            this._context = context;
        }
    }
