        using System.Data.Entity;
    
        namespace EFTest
        {
            class Program
            {
                static void Main(string[] args)
                {
                    var connectionString = "<your connection string>";
                    var context = new DatabaseContext(connectionString);
    
                    var car = new Car();
                    var driver = new Driver();
    
                    context.Cars.Add(car);
                    context.Drivers.Add(driver);
                    car.Driver = driver;
    
                    context.SaveChanges();
    
                }
            }
    
            public class Car
            {
                public int Id { get; set; }
                public virtual Driver Driver { get; set; }
            }
            public class Driver
            {
                public int Id { get; set; }
            }
    
            public class DatabaseContext : DbContext, IDatabaseContext
            {
                public DbSet<Car> Cars { get; set; }
                public DbSet<Driver> Drivers { get; set; }
    
                public DatabaseContext(string connectionString) : base(connectionString){ }
    
                protected override void OnModelCreating(DbModelBuilder modelBuilder)
                {
                    modelBuilder.Entity<Car>()
                        .HasKey(n => n.Id)
                        .HasOptional(n => n.Driver);
    
                    modelBuilder.Entity<Driver>()
                        .HasKey(n => n.Id);
                }
    
            }
        }
