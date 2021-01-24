    public interface IRepairDbSets
    {
        DbSet<Repair> Repairs { get; set; }
        DbSet<Service> Services { get; set; }
    }
    public interface IAutoDbSets
    {
        DbSet<Car> Cars { get; set; }
        DbSet<Van> Vans { get; set; }
    }
    public class ApplicationDbContext : DbContext, IAutoDbSets, IRepairDbSets
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Van> Vans { get; set; }
        public DbSet<Repair> Repairs { get; set; }
        public DbSet<Service> Services { get; set; }
    }
