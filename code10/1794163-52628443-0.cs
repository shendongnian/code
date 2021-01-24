    private T Copy<T>(T original)
    {
        Type type = original.GetType();
        var copy = Activator.CreateInstance<T>();
        var props = type.GetProperties();           
        foreach (var prop in props)
        {
            // Get the value of the original objects property
            var originalPropertyValue = prop.GetValue(original, null);
            // Set the value to the new objects property
            prop.SetValue(copy, originalPropertyValue);
        }
        return copy;
    }
