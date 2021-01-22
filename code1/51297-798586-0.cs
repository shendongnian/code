    object GetThePropertyValue(TheClass instance)
    {
        Type type = instance.GetType();
        PropertyInfo propertyInfo = type.GetProperty("TheProperty");
        return propertyInfo.GetValue(instance, null);
    }
