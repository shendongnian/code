        internal class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MyAppContext>
        {
            public MyAppContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder<MyAppContext>();
                builder.UseSqlServer(_dbConnection);
                var context = new MyAppContext(builder.Options);
                return context;
            }
        }
