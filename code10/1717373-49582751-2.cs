    public static object ExtendedChangeType(object value, Type targetType)
    {
        if (value == null)
            return null;
        targetType = Nullable.GetUnderlyingType(targetType) ?? targetType;
        if (targetType.IsEnum)
        {
            if (value is string)
            {
                return Enum.Parse(targetType, value as string);
            }
            else
            {
                value = Convert.ChangeType(value, Enum.GetUnderlyingType(targetType));
                return Enum.ToObject(targetType, value);
            }
        }
        else
        {
            return Convert.ChangeType(value, targetType);
        }
    }
