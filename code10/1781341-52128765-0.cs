    var keyProperties = modelBuilder
        .Model
        .GetEntityTypes()
        .SelectMany(e => e.GetProperties())
        .Where(p => p.Name == p.DeclaringEntityType.ClrType.Name + "_ID")
        .ToList();
    foreach (var p in keyProperties)
    {
        modelBuilder
            .Entity(p.DeclaringEntityType.Name)
            .HasKey(p.Name);
    }
