    var entityTypes = modelBuilder.Model.GetEntityTypes()
        .Where(t => t.ClrType.IsSubclassOf(typeof(BaseClass)));
    var valueConverter = new ValueConverter<Guid, string>(
        v => v.ToString(), v => (Guid?)Guid.Parse(v));
    foreach (var entityType in entityTypes)
        entityType.FindProperty(nameof(BaseClass.Property1)).SetValueConverter(valueConverter);
