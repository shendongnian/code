    public class YourDbContext : DbContext 
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           if (!optionsBuilder.IsConfigured)
           {
               optionsBuilder.UseSqlServer(Setting.ConnectionString);
           }
        }
    }
