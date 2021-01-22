    using System.Runtime.Serialization;
    
    public static TEnum ToEnum<TEnum>(this string value, TEnum defaultValue) where TEnum : struct
    {
    	if (string.IsNullOrEmpty(value))
    	{
    		return defaultValue;
    	}
    
    	TEnum result;
    	var enumType = typeof(TEnum);
    	foreach (var enumName in Enum.GetNames(enumType))
    	{
    		var fieldInfo = enumType.GetField(enumName);
    		var enumMemberAttribute = ((EnumMemberAttribute[]) fieldInfo.GetCustomAttributes(typeof(EnumMemberAttribute), true)).FirstOrDefault();
    		if (enumMemberAttribute?.Value == value)
    		{
    			return Enum.TryParse(enumName, true, out result) ? result : defaultValue;
    		}
    	}
    
    	return Enum.TryParse(value, true, out result) ? result : defaultValue;
    }
