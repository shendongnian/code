	/// <summary>
	/// Parses string to TEnum without try/catch and .NET 4.5 TryParse()
	/// </summary>
	public static bool TryParseToEnum<TEnum>(string probablyEnumAsString_, out TEnum enumValue_) where TEnum : struct
	{
		enumValue_ = (TEnum)Enum.GetValues(typeof(TEnum)).GetValue(0);
		if(!Enum.IsDefined(typeof(TEnum), probablyEnumAsString_))
			return false;
		enumValue_ = (TEnum) Enum.Parse(typeof(TEnum), probablyEnumAsString_);
		return true;
	}
