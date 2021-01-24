    public class MyContext : DbContext
        {
            public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                SetBaseValues();
                return base.SaveChangesAsync(cancellationToken);
            }
    
            public override int SaveChanges()
            {
                SetBaseValues();
                return base.SaveChanges();
            }
    
            private void SetBaseValues()
            {
                var addedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Added);
                var utcNow = DateTime.UtcNow;
                foreach (var entry in addedEntries)
                {
                    entry.Property("CreatedDateTime").CurrentValue = utcNow;
                    entry.Property("CreatedBy").CurrentValue = UserData.GetCurrentUserId();
                }
                var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
                foreach (var entry in modifiedEntries)
                {
                    entry.Property("CreatedDateTime").IsModified = false;
                    entry.Property("CreatedBy").IsModified = false;
                    entry.Property("ModifiedDateTime").CurrentValue = utcNow;
                    entry.Property("ModifiedBy").CurrentValue = UserData.GetCurrentUserId();
                }
            }
        }
