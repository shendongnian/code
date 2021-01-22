    public static void Copy(object source, object destination,
        string propertyName) {
        PropertyInfo sourceProp = source.GetType().GetProperty(propertyName);
        PropertyInfo destProp = destination.GetType().GetProperty(propertyName);
        destProp.SetValue(destination, sourceProp.GetValue(source, null), null);
    }
