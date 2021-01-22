	public static class EnumExtensions
	{
	  public static string ToName(this Enum enumValue)
	  {
		var displayAttribute = enumValue.GetType()
		  .GetMember(enumValue.ToString())[0]
		  .GetCustomAttributes(false)
		  .Select(a => a as DisplayAttribute)
		  .FirstOrDefault();
		return displayAttribute?.Name ?? enumValue.ToString();
	  }
	}
