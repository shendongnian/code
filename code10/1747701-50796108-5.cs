    public class BlexzWebDb : DbContext 
    {
       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       {
           if (!optionsBuilder.IsConfigured)
           {
               optionsBuilder.UseSqlServer(Setting.ConnectionString);
           }
        }
    }
