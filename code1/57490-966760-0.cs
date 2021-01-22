    private void SetValue(Control control, string propertyName, object value)
    {
        Type type = control.GetType();
        PropertyInfo property = type.GetProperty(propertyName);
        property.SetValue(control, value, null);
    }
    private object GetValue(Control control, string propertyName)
    {
        Type type = control.GetType();
        PropertyInfo property = type.GetProperty(propertyName);
        return property.GetValue(control, null);
    }
