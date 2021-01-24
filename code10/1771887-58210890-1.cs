    public static ModelBuilder ApplyConfiguration<T>(this ModelBuilder modelBuilder, Type configurationType, Type entityType)
    {
        if (typeof(T).IsAssignableFrom(entityType))
        {
            // Build IEntityTypeConfiguration type with generic type parameter
            var configurationGenericType = configurationType.MakeGenericType(entityType);
            // Create an instance of the IEntityTypeConfiguration implementation
            var configuration = Activator.CreateInstance(configurationGenericType);
            // Get the ApplyConfiguration method of ModelBuilder via reflection
            var applyEntityConfigurationMethod = typeof(ModelBuilder)
                .GetMethods()
                .Single(e => e.Name == nameof(ModelBuilder.ApplyConfiguration)
                             && e.ContainsGenericParameters
                             && e.GetParameters().SingleOrDefault()?.ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
            // Create a generic ApplyConfiguration method with our entity type
            var target = applyEntityConfigurationMethod.MakeGenericMethod(entityType);
            // Invoke ApplyConfiguration, passing our IEntityTypeConfiguration instance
            target.Invoke(modelBuilder, new[] { configuration });
        }
    
        return modelBuilder;
    }
