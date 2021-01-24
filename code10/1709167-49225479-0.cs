    //ApplicationDbContext.cs
        public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
     {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    
    //Auto.cs
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //Tables
        public DbSet<Car> Cars { get; set; }
        public DbSet<Van> Vans { get; set; }
        public DbSet<Truck> Trucks { get; set; }
    
       }
