        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }
        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            AddTimestamps();
            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => (x.Entity is DBEntity) && (x.State == EntityState.Added || x.State == EntityState.Modified));
            var now = DateTime.UtcNow; // current datetime
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    ((DBEntity)entity.Entity).CreatedOn = now;
                    ((DBEntity)entity.Entity).EntityStatus = EntityStatus.Created;
                }
                ((DBEntity)entity.Entity).UpdatedOn= now;
            }
        }
