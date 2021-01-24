    class Program
    {
        static void Main(string[] args)
        {
            using (var db=new SampleContext())
            {
                db.Database.EnsureCreated();
                db.MasterTypes.Add(new MasterType()
                {
                    Id = "CA8301",
                    Name = "Type1"
                });
                db.MasterTypes.Add(new MasterType()
                {
                    Id = "CA8301",
                    Name = "Type2"
                });
                db.SaveChanges();
            }
        }
    }
    public class SampleContext : DbContext
    {
        public DbSet<MasterType> MasterTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterType>()
                .HasKey(o => new { o.Id, o.Name});
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyDb;Trusted_Connection=True;");
        }
    }
    public class MasterType
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
