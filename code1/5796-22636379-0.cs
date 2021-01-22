    public static TEnum ParseToEnum<TEnum>(this string text) where TEnum : struct, IConvertible, IComparable, IFormattable
    {
		if (string.IsNullOrEmpty(text) || !typeof(TEnum).IsEnum)
			throw new ArgumentException("TEnum must be an Enum type");
		try
		{
			var enumValue = (TEnum)Enum.Parse(typeof(TEnum), text.Trim(), true);
			return enumValue;
		}
		catch (Exception)
		{
			throw new ArgumentException("{0} is not a member of the Colors enumeration.", text);
		}
    }
