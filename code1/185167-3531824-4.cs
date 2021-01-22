    string modelProperty = "Some Property Name";
    string value = "SomeValue";
    var property = entity.GetType().GetProperty(modelProperty);
    if (property != null)
    {
        Type t = Nullable.GetUnderlyingType(property.PropertyType)
                     ?? property.PropertyType;
        object safeValue = (value == null) ? null
                                           : Convert.ChangeType(value, t);
        property.SetValue(entity, safeValue, null);
    }
