    public static void CopyPropertyValues(object source, object destination)
    {
        var destProperties = destination.GetType().GetProperties();
        foreach (var sourceProperty in source.GetType().GetProperties())
        {
            foreach (var destProperty in destProperties)
            {
                if (destProperty.Name == sourceProperty.Name && 
            destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                {
                    destProperty.SetValue(destination, sourceProperty.GetValue(
                        source, new object[] { }), new object[] { });
                    break;
                }
            }
        }
    }
