    Type type = license.GetType();
    PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
    foreach(PropertyInfo property in properties)
    {
    //compare your properties with property.GetValue(newLicense, null) and property.GetValue(originalLicense, null);
    }
