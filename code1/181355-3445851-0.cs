    public static TConvert ConvertTo<TConvert>(this object entity) where TConvert : new()
    {
        var convertProperties = TypeDescriptor.GetProperties(typeof(TConvert)).Cast<PropertyDescriptor>();
        var entityProperties = TypeDescriptor.GetProperties(entity).Cast<PropertyDescriptor>();
        var convert = new TConvert();
        foreach (var entityProperty in entityProperties)
        {
            var property = entityProperty;
            var convertProperty = convertProperties.FirstOrDefault(prop => prop.Name == property.Name);
            if (convertProperty != null)
            {
                convertProperty.SetValue(convert, Convert.ChangeType(entityProperty.GetValue(entity), convertProperty.PropertyType));
            }
        }
        return convert;
    }
