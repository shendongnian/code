        public class DesignTimeActivitiesDbContextFactory : IDesignTimeDbContextFactory<ActivitiesDbContext>
        {
            public ActivitiesDbContext CreateDbContext(string[] args)
            {
                DbContextOptionsBuilder<ActivitiesDbContext> builder = new DbContextOptionsBuilder<ActivitiesDbContext>();
    
                var context = new ActivitiesDbContext(
                    builder
                    .UseSqlServer("Data Source=(local)\LocalDB;Initial Catalog=DB_name;Integrated Security=True;")
                    .Options);
    
                return context;
            }
        }
