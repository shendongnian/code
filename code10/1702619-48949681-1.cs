    MyType myObject = ...
    IEnumerable<PropertyInfo> propertiesToDisplay = typeof<MyType>.GetProperties()
        .Where(propertyInfo => propertyInfo.CanRead);
    IEnumerable<DisplayValue> displayValues = propertiesToDisplay
        .Select(property => new DisplayValue()
        {
            Description = property.Name,
            Value = property.GetValue(myObject),
        });
