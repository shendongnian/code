    public class SampleContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
