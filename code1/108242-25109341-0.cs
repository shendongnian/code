	public static class Extensions 
	{
	    public static Tuple<string, string> GetDisplayAttributesFrom(this Enum enumValue, Type enumType)
		{
			var metadata = enumType.GetMember(enumValue.ToString())
			    .First()
				.GetCustomAttribute<DisplayAttribute>();
				
			return new Tuple<string, string>(metadata.Name, metadata.Description);
		}
	}
