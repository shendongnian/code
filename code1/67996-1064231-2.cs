    public string FindConstantName<T>(Type containingType, T value)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        foreach (FieldInfo field in containingType.GetFields
                 (BindingFlags.Static | BindingFlags.Public))
        {
            if (field.FieldType == typeof(T) &&
                comparer.Equals(value, (T) field.GetValue(null)))
            {
                return field.Name; // There could be others, of course...
            }
        }
        return null; // Or throw an exception
    }
