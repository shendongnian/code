    using System.Data.Entity;
    namespace EFTest
    {
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "your connection string";
            var context = new DatabaseContext(connectionString);
            //Create a car, a driver, and assign them
            var car = new Car();
            var driver = new Driver();
            context.Cars.Add(car);
            context.Drivers.Add(driver);
            context.SaveChanges();
            var assignment = new DriverAssignment() { Car_id = car.Id, Driver_Id = driver.Id };
            context.DriverAssignments.Add(assignment);
            context.SaveChanges();
            //Create a new car and a new assignment
            var dupCar = new Car();
            context.Cars.Add(dupCar);
            context.SaveChanges();
            var dupAssignment = new DriverAssignment() { Car_id = dupCar.Id, Driver_Id = driver.Id };
            context.DriverAssignments.Add(dupAssignment);
            //This will throw an exception because it will violate the unique index for driver.  It would work the same for car.
            context.SaveChanges();
        }
    }
    public class Car
    {
        public int Id { get; set; }
    }
    public class Driver
    {
        public int Id { get; set; }
    }
    public class DriverAssignment
    {
        public int Car_id { get; set; }
        public int Driver_Id { get; set; }
    }
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverAssignment> DriverAssignments { get; set; }
        public DatabaseContext(string connectionString) : base(connectionString) { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().HasKey(n => n.Id);
            modelBuilder.Entity<Driver>().HasKey(n => n.Id);
            modelBuilder.Entity<DriverAssignment>().HasKey(n => new { n.Car_id, n.Driver_Id });
            modelBuilder.Entity<DriverAssignment>().HasIndex(n => n.Car_id).IsUnique();
            modelBuilder.Entity<DriverAssignment>().HasIndex(n => n.Driver_Id).IsUnique();
        }
    }
}
