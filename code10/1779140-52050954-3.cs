    public override int SaveChanges()
    {
       ChangeTracker.DetectChanges();
       IEnumerable<EntityEntry> deletedEntities = ChangeTracker.Entries()
                                                               .Where(t => t.State == EntityState.Deleted && t.Entity is ISof
       foreach (EntityEntry deletedEntity in deletedEntities)
       {
           if (!(deletedEntity.Entity is ISoftDeletable item)) continue;
           item.IsDeleted = true;
           deletedEntity.State = EntityState.Modified;
       }
       IEnumerable<object> addedEntities = ChangeTracker.Entries()
                                                        .Where(t => t.State == EntityState.Added && t.Entity is IAudit)
                                                        .Select(t => t.Entity);
       IEnumerable<object> modifiedEntities = ChangeTracker.Entries()
                                                           .Where(t => t.State == EntityState.Modified && t.Entity is IAudit)
                                                           .Select(t => t.Entity);
       DateTime now = DateTime.UtcNow;
       Parallel.ForEach(addedEntities, o =>
                                       {
                                           if (!(o is IAudit item))
                                               return;
                                           item.CreateDate = now;
                                           item.UpdateDate = now;
                                           item.CreatedBy = item.UpdatedBy;
                                       });
       Parallel.ForEach(modifiedEntities, o =>
                                          {
                                              if (!(o is IAudit item))
                                                  return;
                                              item.UpdateDate = now;
                                          });
       return base.SaveChanges();
    }
