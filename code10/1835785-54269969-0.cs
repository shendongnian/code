csharp
static object GetPropertyValue(object parent, string nestedPropertyName)
{
    object propertyValue = null;
    var tokens = nestedPropertyName.Split('.');
    foreach (var token in tokens)
    {
      var property = parent.GetType().GetProperty(token, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
      propertyValue = property.GetValue(parent);
      if (propertyValue is null) return null;
      parent = propertyValue;
    }
    return propertyValue;
}
