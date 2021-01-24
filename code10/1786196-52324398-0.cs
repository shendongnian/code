        public class ApplicationDbContextTest : IdentityDbContext<Person>
    {
        public DbSet<MyDocument> Document { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreDemo;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
    public class User : IdentityUser
    {
    }
    public class Person : User
    {
    }
    public class MyDocument:Document
    {
        public new Person Owner { get; set; }
    }
    public class Document
    {
        public int Id { get; set; }
        public User Owner { get; set; }
    }
