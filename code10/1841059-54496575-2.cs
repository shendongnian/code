    public class FooContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder) {     
               builder.UseSqlite("Data Source=Database.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DateTime parsedDateTime;
            var converter = new ValueConverter<string, DateTime?>(
                v => string.IsNullOrWhiteSpace(v)
                    ? null
                    : DateTime.TryParse(v, out parsedDateTime)
                        ? parsedDateTime
                        : (DateTime?) null,
                v => v != null
                    ? v.ToString()
                    : string.Empty);
            modelBuilder
               .Entity<Bar>()
               .Property(b=>b.SomeDate)
               .HasConversion(converter);
        }    
    
        public DbSet<Bar> Bar { get; set; }
    }
