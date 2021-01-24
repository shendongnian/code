    protected override void OnModelCreating(ModelBuilder builder)
            {
    
             var multitenantTypes = typeof(IMultiTenantEntity)
                .Assembly
                .GetTypes()
                .Where(x => typeof(IMultiTenantEntity).IsAssignableFrom(x))
                .ToArray();
    
            foreach (var typeToIgnore in multitenantTypes)
            {
                builder.Ignore(typeToIgnore);
            }
    
        }
