    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    
    }
    
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public int CustomerId {get;set;}
        public virtual Customer Customer { get; set; }
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasOne(a => a.Customer)
            .WithOne(b => b.Course)
            .HasForeignKey<Course>(b => b.CustomerId);
    }
