	namespace CustomExtensions
	{
		public static class ListItemCollectionExtension
		{
			public static void AddEnum<TEnum>(this System.Web.UI.WebControls.ListItemCollection items) where TEnum : struct
			{
				System.Type enumType = typeof(TEnum);
				System.Type enumUnderType = System.Enum.GetUnderlyingType(enumType);
				if (!enumType.IsEnum) throw new Exception("Enumeration type is expected.");
				string[] enumTypeNames = System.Enum.GetNames(enumType);
				TEnum[] enumTypeValues = (TEnum[])System.Enum.GetValues(enumType);
				for (int i = 0; i < enumTypeValues.Length; i++)
				{
					items.add(new System.Web.UI.WebControls.ListItem(enumTypeNames[i], Convert.ChangeType(enumTypeValues[i], enumUnderType).ToString()));	//Sadly you cannot easily get the numeric value of the enumeration in C# using the .ToString overload or converting it to another type (like int).  The problem is an enum can be any whole number base type including uint, long, and ulong.  Since long and long would give different values for 0xFFFF0000, it is better to use the Convert.ChangeType method.
				}
			}
		}
	}
