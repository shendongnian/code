    public static bool IsNullOrEmpty<T>(T value)
    {
        if (IsNull(value))
        {
            return true;
        }
        if (value is string)
        {
            return string.IsNullOrEmpty(value as string);
        }
        return value.Equals(default(T));
    }
    public static bool IsNull<T>(T value)
    {
        if (value is ValueType)
        {
            return false;
        }
        return null == (object)value;
    }
