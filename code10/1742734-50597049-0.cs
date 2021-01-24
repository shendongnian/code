    var sourceProperties = source.GetType().GetProperties();
    var destinationProperties = destination.GetType().GetProperties();
    
    object value = sourceProperty.GetValue(source);
        if (value == null && 
            targetProperty.PropertyType.IsValueType &&
            Nullable.GetUnderlyingType(targetProperty.PropertyType) == null)
        {
            // Code....
        }
        else
        {
            targetProperty.SetValue(target, value);
        }
