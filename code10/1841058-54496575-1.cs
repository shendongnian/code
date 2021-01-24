    public class FooContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {     
               builder.UseSqlite("Data Source=Database.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new ValueConverter<string, DateTime?>(
                v => v !=null 
                     ? v.ToString()
                     : "",
                v => string.IsNullOrWhiteSpace(v) 
                         ? null 
                         : DateTime.TryParse(v, out var dateVal) 
                             ? dateVal 
                             : null));
            modelBuilder
               .Entity<Bar>()
               .Property(b=>b.SomeDate)
               .HasConversion(converter);
        }    
    
        public DbSet<Bar> Bar { get; set; }
    }
