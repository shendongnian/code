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
					items.add(new System.Web.UI.WebControls.ListItem(enumTypeNames[i], (enumTypeValues[i] as System.Enum).ToString("d")));
				}
			}
		}
	}
