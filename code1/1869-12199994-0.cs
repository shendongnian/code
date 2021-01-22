    public static TEnum ParseEnum<TEnum>(string value) where TEnum : struct
    {
		TEnum tmp; 
		if (!Enum.TryParse<TEnum>(value, true, out tmp))
        {
            tmp = new TEnum();
        }
		return tmp;
    }
