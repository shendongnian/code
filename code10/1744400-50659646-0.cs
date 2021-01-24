    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    namespace yournamespace
    {
        public class YourDbContextDesignTimeFactory : IDesignTimeDbContextFactory<YourDbContext>
        {
            public YourDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<YourDbContext>();
                builder.UseSqlite("Data Source=somename.db");
                return new YourDbContext(builder.Options);
            }
        }
    }
