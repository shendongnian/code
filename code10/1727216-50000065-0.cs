    public class Employee
    {
        public int Id { get; set; }
        public Car Car { get; set; }
        public int? CarId { get; set; }
    }
    public class Car
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Car> Cars { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOptional(c => c.Employee)
                .WithOptionalDependent(e => e.Car)
                .Map(config =>
                {
                    config.MapKey("EmployeeId");
                });
            base.OnModelCreating(modelBuilder);
        }
    }
