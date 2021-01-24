    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> {
            public ApplicationDbContext CreateDbContext(string[] args) {
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                string connectionString = Config.GetConnectionString("AppDbContext");
                builder.UseMySql(connectionString);
    
                return new ApplicationDbContext(builder.Options);
            }
        }
