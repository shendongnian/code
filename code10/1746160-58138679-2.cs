csharp
foreach (var entity in builder.Model.GetEntityTypes())
{
    foreach (var property in entity.ClrType.GetProperties())
    {
        if (property.PropertyType == typeof(List<string>))
        {
            builder.Entity(entity.Name).Property(property.Name).HasConversion(new ValueConverter<List<string>, string>(v => v.ToJson(), v => v.FromJson<List<string>>())).HasColumnType("json");
        }
        else if (property.PropertyType == typeof(Dictionary<string, string>))
        {
            builder.Entity(entity.Name).Property(property.Name).HasConversion(new ValueConverter<Dictionary<string, string>, string>(v => v.ToJson(), v => v.FromJson<Dictionary<string, string>>())).HasColumnType("json");
        }
        else if (property.PropertyType == typeof(List<List<string>>))
        {
            builder.Entity(entity.Name).Property(property.Name).HasConversion(new ValueConverter<List<List<string>>, string>(v => v.ToJson(), v => v.FromJson<List<List<string>>>())).HasColumnType("json");
        }
        else if (property.PropertyType == typeof(bool))
        {
            builder.Entity(entity.Name).Property(property.Name).HasConversion(new BoolToZeroOneConverter<short>());
        }
    }
}
