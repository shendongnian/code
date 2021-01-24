    class Program
    {
        static void Main(string[] args)
        {
            var db = new ApplicationDbContext();
            var person = new Person();
            IQueryable<Link> personLinks = db.Links.Where(x => x.PersonId == person.Id);
            List<Area> personAreas = personLinks.GroupBy(x => x.Area).Select(x => x.Key).ToList(); 
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public ICollection<Link> Links { get; set; }
    }
    public class Link
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
    public class Area
    {
        public int Id { get; set; }
        public ICollection<Link> Links { get; set; }
    }
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Link> Links { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Link>()
                .HasRequired(x => x.Person)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.PersonId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Link>()
                .HasRequired(x => x.Area)
                .WithMany(x => x.Links)
                .HasForeignKey(x => x.AreaId)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
