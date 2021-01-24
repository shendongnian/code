    public static class ModelBuilderExtensions
    {
        public static ModelBuilder RemoveAnnotations<TDbContext>(this ModelBuilder modelBuilder, TDbContext context, string name, IList<string> values) where TDbContext : DbContext
        {
            var bindingFlags = 
                BindingFlags.Instance | 
                BindingFlags.Public | 
                BindingFlags.DeclaredOnly;
            var entityMethod =
                typeof(ModelBuilder)
                    .GetMethods()
                    .Single(m =>
                        m.Name == nameof(ModelBuilder.Entity) &&
                        m.GetGenericArguments().Length == 1 &&
                        m.GetParameters().Length == 0
                    )
                    .GetGenericMethodDefinition();
            foreach (var contextProperty in typeof(TDbContext).GetProperties(bindingFlags))
            {
                var entity =
                    contextProperty
                        .PropertyType
                        .GetGenericArguments()
                        .SingleOrDefault();
                if (entity is null)
                {
                    continue;
                }
                // Only the generic overload returns properties. The non-generic one didn't work.
                var generitcEntityMethod = entityMethod.MakeGenericMethod(entity);
                foreach (var property in entity.GetProperties(bindingFlags))
                {
                    var entityTypeBuilder = (EntityTypeBuilder)generitcEntityMethod.Invoke(modelBuilder, null);
                    if (entityTypeBuilder.Metadata.FindProperty(property) is null)
                    {
                        continue;
                    }
                    var annotation = 
                        entityTypeBuilder
                            .Property(property.Name)
                            .Metadata
                            .FindAnnotation(name);
                    if (values.Contains(annotation?.Value))
                    {
                        entityTypeBuilder
                            .Property(property.Name)
                            .Metadata
                            .RemoveAnnotation(name);
                    }
                }
            }
            return modelBuilder;
        }
    }
