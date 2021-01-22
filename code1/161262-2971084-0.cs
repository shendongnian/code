    /// <summary>
    /// Uses reflection to set the field value in an object.
    /// </summary>
    ///
    /// <param name="type">The instance type.</param>
    /// <param name="instance">The instance object.</param>
    /// <param name="fieldName">The field's name which is to be fetched.</param>
    /// <param name="fieldValue">The value to use when setting the field.</param>
    internal static void SetInstanceField(Type type, object instance, string fieldName, object fieldValue)
    {
        BindingFlags bindFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic
            | BindingFlags.Static;
        FieldInfo field = type.GetField(fieldName, bindFlags);
        field.SetValue(instance, fieldValue);
    }
