    public partial class MyContext : DbContext
    {
        private readonly string _connectionString;
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }
        public MyContext(IOptions<DbConnectionInfo> dbConnectionInfo)
        {
            _connectionString = dbConnectionInfo.Value.MyContext;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
