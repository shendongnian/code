    public partial class MyContext : DbContext
    {
        private readonly string _connectionString;
        public MyContext(DbConnectionInfo dbConnectionInfo)
        {
            _connectionString = dbConnectionInfo.MyContext;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder     optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
