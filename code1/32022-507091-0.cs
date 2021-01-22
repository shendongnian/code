    public class Enum<EnumType> where EnumType : struct, IConvertible
    {
    
    	/// <summary>
    	/// Retrieves an array of the values of the constants in a specified enumeration.
    	/// </summary>
    	/// <returns></returns>
    	/// <remarks></remarks>
    	public static EnumType[] GetValues()
    	{
    		return (EnumType[])Enum.GetValues(typeof(EnumType));
    	}
    
    	/// <summary>
    	/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
    	/// </summary>
    	/// <param name="name"></param>
    	/// <returns></returns>
    	/// <remarks></remarks>
    	public static EnumType Parse(string name)
    	{
    		return (EnumType)Enum.Parse(typeof(EnumType), name);
    	}
    
    	/// <summary>
    	/// Converts the string representation of the name or numeric value of one or more enumerated constants to an equivalent enumerated object.
    	/// </summary>
    	/// <param name="name"></param>
    	/// <param name="ignoreCase"></param>
    	/// <returns></returns>
    	/// <remarks></remarks>
    	public static EnumType Parse(string name, bool ignoreCase)
    	{
    		return (EnumType)Enum.Parse(typeof(EnumType), name, ignoreCase);
    	}
    
    	/// <summary>
    	/// Converts the specified object with an integer value to an enumeration member.
    	/// </summary>
    	/// <param name="value"></param>
    	/// <returns></returns>
    	/// <remarks></remarks>
    	public static EnumType ToObject(object value)
    	{
    		return (EnumType)Enum.ToObject(typeof(EnumType), value);
    	}
    }
