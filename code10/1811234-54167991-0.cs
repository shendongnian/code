    public class ApiDbContextMigrationsFactory : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Api.Local.Migration;Trusted_Connection=True;ConnectRetryCount=0",
                b => b.MigrationsAssembly(typeof(ApiDbContext).Assembly.FullName));
            return new ApiDbContext(optionsBuilder.Options);
        }
    }
