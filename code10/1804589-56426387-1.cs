    public class DataContext : DbContext
    {
      public virtual DbSet<BaseSetting> Settings { get; set; }
      protected override void OnModelCreating(ModelBuilder builder)
      {
        base.OnModelCreating(builder);
        
        builder.Entity<BaseSetting>(e =>
        {
            e.ToTable("Settings");
            e.HasDiscriminator<string>("Type");
        });
      }
    }
