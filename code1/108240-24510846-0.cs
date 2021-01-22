    public static IDictionary<string, int> ToDictionary(this Type enumType)
    {
    	return Enum.GetValues(enumType)
    	.Cast<object>()
    	.ToDictionary(v => ((Enum)v).ToEnumDescription(), k => (int)k); 
    }
