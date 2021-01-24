    public class TestDbContext : DbContext
    {
        public TestDbContext() : base("ThisIsMyConnectionStringName")
        {  
        }
    
        public static TestDbContext Create()
        {
            return new TestDbContext();
        }
    
        public DbSet<holidays> holidays { get; set; }
    }
      <connectionStrings>
        <add name="ThisIsMyConnectionStringName" connectionString="Data Source=(LocalDb)\v11.0;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\My-Database-Name.mdf" providerName="System.Data.SqlClient" />
      </connectionStrings>
