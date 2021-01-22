    public string FindConstantName<T>(Type containingType, T value)
    {
        EqualityComparer<T> comparer = EqualityComparer<T>.Default;
        foreach (FieldInfo field in containingType.GetFields
                 (BindingFlags.Static | BindingFlags.Public))
        {
            if (comparer.Equals(value, field.GetValue(null))
            {
                return field.Name; // There could be others, of course...
            }
        }
        return null; // Or throw an exception
    }
