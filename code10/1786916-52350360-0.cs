    using Microsoft.Data.Sqlite;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Xunit;
    public class Tests
    {
        [Fact]
        public void PersonCustomContext_can_get_PersonCustom()
        {
            var connection = new SqliteConnection("datasource=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;
            using (var ctx = new PersonContext(options))
                ctx.Database.EnsureCreated();
            using (var ctx = new PersonContext(options))
            {
                ctx.Add(new Person { FirstName = "John", LastName = "Doe" });
                ctx.SaveChanges();
            }
            using (var ctx = new PersonCustomContext(options))
            {
                Assert.Equal("John Doe", ctx.People.Single().FullName);
            }
        }
    }
    public class PersonContext : DbContext
    {
        public PersonContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
    }
    public class PersonCustomContext : DbContext
    {
        public PersonCustomContext(DbContextOptions options) : base(options) { }
        public DbSet<PersonCustom> People { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonCustom>(builder =>
            {
                builder.HasKey(p => p.PersonId);
            });
        }
    }
    public class Person
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual string FullName => $"{LastName}, {FirstName}";
    }
    public class PersonCustom : Person
    {
        public override string FullName => $"{FirstName} {LastName}";
    }
