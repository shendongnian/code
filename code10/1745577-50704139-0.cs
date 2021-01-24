    foreach (Type entityType in entityTypes)
    {
         Type openConfigType = typeof(BaseEntityConfiguration<>);
         Type genericConfigType = openConfigType.MakeGenericType(entityType);
         builder.ApplyConfiguration(Activator.CreateInstance(genericConfigType));           
    }
