    var dataType = myInstance.GetType();
    var allProperties = dataType.GetProperties(BindingFlags.Public | BindingFlags.Instance);
    var listProperties =
      allProperties.
        Where(prop => prop.PropertyType.GetInterfaces().
          Any(i => i == typeof(IList)));
