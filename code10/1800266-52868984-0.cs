    foreach (var entityType in modelBuilder.Model.GetEntityTypes())
    {
        if (typeof(ITiming).IsAssignableFrom(entityType.ClrType))
        {
            entityType.FindProperty(nameof(ITiming.CreatedAt))
                .AfterSaveBehavior = PropertySaveBehavior.Ignore;
        }
    }
