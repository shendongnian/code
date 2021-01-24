    var configurations = typeof(MyDbContext).Assembly.GetTypes()
                    .Where(t => t.BaseType != null && t.BaseType.IsGenericType && t.BaseType.GetGenericTypeDefinition() == typeof(System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<>));
                        
    foreach (var config in configurations)
    {
        dynamic instance = System.Activator.CreateInstance(config);
        modelBuilder.Configurations.Add(instance);
    }
