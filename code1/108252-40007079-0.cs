    public static class EnumHelper
    {
    	/// <summary>
    	/// Gets an attribute on an enum field value
    	/// </summary>
    	/// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
    	/// <param name="enumVal">The enum value</param>
    	/// <returns>The attribute of type T that exists on the enum value</returns>
    	/// <example>string desc = myEnumVariable.GetAttributeOfType<DescriptionAttribute>().Description;</example>
    	public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
    	{
    		var type = enumVal.GetType();
    		var memInfo = type.GetMember(enumVal.ToString());
    		IEnumerable<Attribute> attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
    		return (T)attributes?.ToArray()[0];
    	}
    }
