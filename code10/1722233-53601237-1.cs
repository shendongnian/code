	public class DbContextOptions_MSSQL : IDbContextOptions
    {
        public DbContextOptions Options { get; set; }
        public DbContextOptions_MSSQL(string connectionString)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseSqlServer(connectionString);
            Options = builder.Options;
        }
    }
	public class DbContextOptions_MySQL : IDbContextOptions
    {
        public DbContextOptions Options { get; set; }
        public DbContextOptions_MySQL(string connectionString)
        {
            DbContextOptionsBuilder builder = new DbContextOptionsBuilder();
            builder.UseMySql(connectionString);
            Options = builder.Options;
        }
    }
