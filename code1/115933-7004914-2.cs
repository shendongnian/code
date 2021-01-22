    public static TEnum ToDescriptionEnum<TEnum>(this string description)
    {
        Type enumType = typeof(TEnum);
        foreach (string name in Enum.GetNames(enumType))
        {
            var enValue = Enum.Parse(enumType, name);
            if (Description((Enum)enValue).Equals(description)) {
                return (TEnum) enValue;
            }
        }
        throw new TargetException("The string is not a description or value of the specified enum.");
    }
