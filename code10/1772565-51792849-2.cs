    public class DesignTimeActivitiesDbContextFactory : IDesignTimeDbContextFactory<ActivitiesDbContext>
    {
        public ActivitiesDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.Development.json", optional: false);
            var config = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<ActivitiesDbContext>()
                .UseSqlServer(config.GetConnectionString("DefaultConnection"));
            return new ActivitiesDbContext(optionsBuilder.Options);
        }
    }
