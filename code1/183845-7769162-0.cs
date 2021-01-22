    public class EFDbContext : DbContext
    {
       protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Class>().Property(object => object.property).HasPrecision(12, 10);
       }
    }
