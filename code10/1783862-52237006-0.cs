    public class DBContextFactory : IDesignTimeDbContextFactory<DbContext>
    { 
        public DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DbContext>();
            builder.UseSqlServer(
                "Server=(local)\\serverName;Database=dbName;Trusted_Connection=True;MultipleActiveResultSets=true");
    
            return new DbContext(builder.Options);
        }
    }
