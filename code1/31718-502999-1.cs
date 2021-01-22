    public static TEnum ToEnum<TInput, TEnum>(this TInput value)
    {
        Type type = typeof(TEnum);
        if (value == default(TInput))
        {
            throw new ArgumentException("Value is null or empty.", "value");
        }
        if (!type.IsEnum)
        {
            throw new ArgumentException("Enum expected.", "TEnum");
        }
        return (TEnum)Enum.Parse(type, value.ToString(), true);
    }
