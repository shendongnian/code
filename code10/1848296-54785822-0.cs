    public static TEnum ParseEnum<TEnum>(this string enumValue, bool ignoreCase = true) where TEnum : struct
    {
        if (!Enum.TryParse(enumValue, ignoreCase, out TEnum result))
        {
            throw new ArgumentException(
                $"{enumValue} is not a valid {typeof(TEnum).Name}",
                typeof(TEnum).Name);
        }
        return result;
    }
