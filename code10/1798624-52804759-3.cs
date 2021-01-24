        public static void InmutableCollumn<TEntity>(this ModelBuilder modelBuilder, params Expression<Func<TEntity, object>>[] propertiesExpression) where TEntity : class
        {
            foreach(var propertyExpression in propertiesExpression)
                modelBuilder.Entity<TEntity>()
                    .Property(propertyExpression)
                    .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
        }
