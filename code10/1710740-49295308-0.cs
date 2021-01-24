    public class EFDbContext : DbContext
    {
        public EFDbContext() : base(@"data source=(local);initial catalog=xxx;integrated security=false;userid=sa;password=yyy;MultipleActiveResultSets=True;App=EntityFramework")
        {
            this.Database.Connection.Provider = "System.Data.SqlClient";
        }
    }
