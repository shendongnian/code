    public static object ExtendedChangeType(object value, Type targetType)
    {
        targetType = Nullable.GetUnderlyingType(targetType) ?? targetType;
        if (targetType.IsEnum)
        {
            value = Convert.ChangeType(value, Enum.GetUnderlyingType(targetType));
            return Enum.ToObject(targetType, value);
        }
        else
        {
            return Convert.ChangeType(value, targetType);
        }
    }
