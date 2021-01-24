    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public UserContext CreateDbContext(string[] args)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
                var builder = new DbContextOptionsBuilder<AppDbContext>();
                var connectionString = configuration.GetConnectionString("UserDatabase");
                builder.UseSqlServer(connectionString);
                return new AppDbContext(builder.Options);
            }
        }
