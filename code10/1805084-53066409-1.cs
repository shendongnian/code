    public class Example
    {
        [Key, Column(Order = 0)]
        public int Col1 { get; set; }
        [Key, Column(Order = 1)]
        public int Col2 { get; set; }
        [Key, Column(Order = 2)]
        public int Col3 { get; set; }
        public string Data { get; set; }
    }
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Example> Examples { get; set; }
        public override int SaveChanges()
        {
            ValidateEntities();
            return base.SaveChanges();
        }
        private void ValidateEntities()
        {
            var hasChanges = ChangeTracker.Entries()
               .Any(x => (x.Entity is Example) && (x.State == EntityState.Added || x.State == EntityState.Modified));
            if (!hasChanges)
            {
                return;
            }
            var addedEntries = ChangeTracker.Entries()
               .Where(x => (x.Entity is Example) && x.State == EntityState.Added)
               .Select(x => x.Entity as Example);
            // The tricky is right here: this.Examples.Where(...), will it execute in DB or local?
            var existingEntities = this.Examples.Where(x => addedEntries.Any(e => e.Col1 == x.Col1 && e.Col2 == x.Col2 && x.Col3 == e.Col3));
            if (existingEntities.Any())
            {
                var keys = string.Join("; ", existingEntities.Select(x => $"{x.Col1}-{x.Col2}-{x.Col3}"));
                throw new Exception($"{keys} already exist.");
            }
            var modifiedEntries = ChangeTracker.Entries()
                .Where(x => (x.Entity is Brand) && x.State == EntityState.Modified);
            if (modifiedEntries.Any())
            {
                return;
            }
            ////TO DO: the rest code for modified entries, more complex than added part.
        }
    }
