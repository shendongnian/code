      public static EntityTypeBuilder<TEntity> EnableConcurrency<TEntity>(this EntityTypeBuilder<TEntity> entityTypeBuilder) where TEntity : class
            {
                var entity = entityTypeBuilder.Metadata.Model.FindEntityType(typeof(TEntity));
                foreach (var prop in entity.GetProperties())
                {
                    prop.IsConcurrencyToken = true;
                }
                return entityTypeBuilder;
            }
