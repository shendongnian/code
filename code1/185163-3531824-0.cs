    string modelProperty = "Some Property Name";
    string value = "SomeValue";
    var property = entity.GetType().GetProperty(modelProperty);
    if (property != null)
    {
        object safeValue = null;
        Type u = Nullable.GetUnderlyingType(property.PropertyType);
        if (u == null)
            safeValue = Convert.ChangeType(value, property.PropertyType);
        else if (value != null)
            safeValue = Convert.ChangeType(value, u);
        else
            safeValue = null;
        property.SetValue(entity, safeValue, null);
    }
