    public static TEnum ConvertByName<TEnum>(this Enum source, bool ignoreCase = false) where TEnum : struct
    {
    	// if limited by lack of generic enum constraint
    	if (!typeof(TEnum).IsEnum)
    	{
    		throw new InvalidOperationException("enumeration type required.");
    	}
    
    	TEnum result;
    	if (!Enum.TryParse(source.ToString(), ignoreCase, out result))
    	{
    		throw new Exception("conversion failure.");
    	}
    
    	return result;
    }
