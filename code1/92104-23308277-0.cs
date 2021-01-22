    public static void SetValue(object target, string propertyName, object value)
    {
      if (target == null)
        return;
      PropertyInfo propertyInfo = target.GetType().GetProperty(propertyName);
      object convertedValue = value;
      if (value != null && value.GetType() != propertyInfo.PropertyType)
      {
        Type propertyType = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
        convertedValue = Convert.ChangeType(value, propertyType);
      }
      propertyInfo.SetValue(target, convertedValue, null);
    }
