    public class TestDbContext : DbContext
    {
        public TestDbContext()
           : base("mysqldb")
        {  
        }
    
        public static TestDbContext Create()
        {
            return new TestDbContext();
        }
        public DbSet<holidays> holidays { get; set; }
    }
