    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                             .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))).ToList();
    
    
        foreach (var type in typesToRegister)
        {
           dynamic configurationInstance = Activator.CreateInstance(type);
           modelBuilder.ApplyConfiguration(configurationInstance);
        }
    }
