    public override int SaveChanges()
            {
                var entities = from e in ChangeTracker.Entries()
                               where e.State == EntityState.Added
                                   || e.State == EntityState.Modified
                               select e.Entity;
                foreach (var entity in entities)
                {
                    var metaDataEntityInstance = EntityMapper.MapEntity(entity);
                    var validationContext = new ValidationContext(metaDataEntityInstance);
                    Validator.ValidateObject(
                        metaDataEntityInstance,
                        validationContext,
                        validateAllProperties: true);
                }
    
                return base.SaveChanges();
            }
