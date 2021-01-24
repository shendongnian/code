	public class MyDbContext_MSSQL : MyDbContext, IMigrationContext
    {
        public MyDbContext_MSSQL(DbContextOptions options) : base(options)
        {
         
        }
    }	
	
	public class MyDbContext_MySQL : MyDbContext, IMigrationContext
    {
        public MyDbContext_MySQL(DbContextOptions options) : base(options)
        {
        }
    }
	
