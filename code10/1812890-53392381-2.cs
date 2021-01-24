    private static bool SetValues(DbContext db, Object objectInstance, 
        Dictionary<string, object> values, PropertyInfo[] properties)
    {
        var entityType = db.Model.FindEntityType(objectInstance.GetType());
        bool edited = false;
        foreach (var item in values)
        {
            var property = entityType.FindProperty(item.Key);
            if (property != null)
            {
                var propertyType = property.ClrType;
                bool isRequired = !property.IsNullable;
                // do something ...     
            }
        }
    }
