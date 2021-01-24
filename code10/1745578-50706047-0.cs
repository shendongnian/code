    // Can be moved to a static readonly field of the class
    var applyConfigurationMethodDefinition = typeof(ModelBuilder)
        .GetTypeInfo()
        .DeclaredMethods
        .Single(m => m.Name == "ApplyConfiguration" &&
            m.IsGenericMethodDefinition &&
            m.GetParameters().Length == 1 &&
            m.GetParameters()[0].ParameterType.IsGenericType &&
            m.GetParameters()[0].ParameterType.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>));
    foreach (var entityType in entityTypes)
    {
        var configurationType = typeof(BaseEntityConfiguration<>).MakeGenericType(entityType);
        var configuration = Activator.CreateIntance(configurationType);
        var applyConfigurationMethod = applyConfigurationMethodDefinition.MakeGenericMethod(entityType);
        applyConfigurationMethod.Invoke(null, new object[] { configuration });
    }
