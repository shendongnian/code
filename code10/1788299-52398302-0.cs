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
                    var entityType = entry.Entity.GetType();
                    entityType.GetProperty("CreatedDateTime").SetValue(entry.Entity, utcNow);
                    entityType.GetProperty("CreatedBy").SetValue(entry.Entity, UserData.GetCurrentUserId());
                    entityType.GetProperty("CompanyId").SetValue(entry.Entity, UserData.GetCurrentUserCompanyId());
                }
                var modifiedEntries = ChangeTracker.Entries().Where(e => e.State == EntityState.Modified);
                foreach (var entry in modifiedEntries)
                {
                    var entityType = entry.Entity.GetType();
                    entityType.GetProperty("ModifiedDateTime").SetValue(entry.Entity, utcNow);
                    entityType.GetProperty("ModifiedBy").SetValue(entry.Entity, UserData.GetCurrentUserId());
                }
            }
        }
