    using ClassLibrary1;
    using Microsoft.EntityFrameworkCore;
    
    namespace EFClassLibrary
    {
        public class ClientDbContext : DbContext
        {
            const string connectionString = "Server=(localdb)\\mssqllocaldb;Database=ClientDb;Trusted_Connection=True;";
    
            public ClientDbContext() : base() { }
    
            public ClientDbContext(DbContextOptions<ClientDbContext> options) : base(options) { }
    
            public DbSet<Person> People { get; set; }
    
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
