    // There may already be a field for this somewhere in the framework...
    private static readonly object[] EmptyArray = new object[0];
    ...
    PropertyInfo prop = typeof(Customer).GetProperty(item.key);
    if (prop == null)
    {
        // Eek! Throw an exception or whatever...
        // You might also want to check the property type
        // and that it's readable
    }
    string value = (string) prop.GetValue(customer, EmptyArray);
    template.SetTemplateAttribute(item.key, value);
