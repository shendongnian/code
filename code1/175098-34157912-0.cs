    /// <summary>
    /// Uses reflection to get the field value from an object.
    /// </summary>
    /// <param name="type">The instance type.</param>
    /// <param name="instance">The instance object.</param>
    /// <param name="fieldName">The field's name which is to be fetched.</param>
    /// <returns>An instance of <see cref="T"/>.</returns>
    internal static T GetInstanceField<T>(Type type, object instance, string fieldName)
    {
        var field = type.GetField(fieldName, BindFlags);
        Assert.IsNotNull(field, string.Format("The field with name '{0}' does not exist in type '{1}'.", fieldName, type));
        var value = field.GetValue(instance);
        Assert.IsInstanceOfType(value, typeof(T), string.Format("The value of the field '{0}' is not of type '{1}'", fieldName, typeof(T)));
        return (T)value;
    }
