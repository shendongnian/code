	public static DisplayAttribute GetDisplayAttributesFrom(this Enum enumValue, Type enumType)
	{
		return enumType.GetMember(enumValue.ToString())
					   .First()
					   .GetCustomAttribute<DisplayAttribute>();
	}
