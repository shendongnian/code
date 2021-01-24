    public class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Customer>(entity=>
            {
                entity.HasOne(customer=>customer.Course)
                    .WithOne(course=> course.Customer)
                    .HasForeignKey<Course>(course=>course.Id); 
            });
        }
        public DbSet<App.Models.Customer> Customer { get; set; }
        public DbSet<App.Models.Course> Courses{ get; set; }
    }
