    public static class ExtensionMethod
    {
        public static void ImmutableCollumn<TEntity, TProperty>(this ModelBuilder modelBuilder, Expression<Func<TEntity, TProperty>> propertyExpression) where TEntity : class
        {
            modelBuilder.Entity<TEntity>()
              .Property(propertyExpression)
                .Metadata.AfterSaveBehavior = PropertySaveBehavior.Ignore;
        }
    }
