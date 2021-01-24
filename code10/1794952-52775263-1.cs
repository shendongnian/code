        protected override DbEntityValidationResult ValidateEntity(
            DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            // validate entity from annotations
            var result = base.ValidateEntity(entityEntry, items);
            // custom validation rules
            if (entityEntry.Entity is Version && 
                (entityEntry.State == EntityState.Added || entityEntry.State == EntityState.Modified))
            {
                Version version = ((Version)entityEntry.Entity);
                if (version.DocumentID == null && version.RegisterID == null)
                    result.ValidationErrors.Add(new DbValidationError(null, "A document or register must be specified."));
            }
            return result;
        }
