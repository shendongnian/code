    public static class DescriptionExtensions
    {
    	public static string Description<TEnum>(this TEnum source) where TEnum : struct, Enum
    		=> typeof(TEnum).GetField(source.ToString()).Description();
    
    	public static string Description(this FieldInfo source)
    		=> source.GetCustomAttribute<DescriptionAttribute>()?.Description ?? source.Name;
    }
