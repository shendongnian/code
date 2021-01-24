    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<StorageContext>
        {
            public StorageContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false)
                    .AddJsonFile("appsettings.Development.json", optional: true)
                    .Build();
    
                var builder = new DbContextOptionsBuilder<StorageContext>();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connectionString);
    
                Console.WriteLine($"Running DesignTime DB context. ({connectionString})");
    
                return new StorageContext(builder.Options);
            }
        }
