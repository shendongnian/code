	namespace CustomExtensions
	{
		public static class ListItemCollectionExtension
		{
			public static void AddEnum<TEnum>(this System.Web.UI.WebControls.ListItemCollection items) where TEnum : struct
			{
				System.Type enumerationType = typeof(TEnum);
				if (!enumerationType.IsEnum) throw new Exception("Enumeration type is expected.");
				string[] enumTypeNames = System.Enum.GetNames(enumerationType);
				object[] enumTypeValues = (object[]) System.Enum.GetValues(enumerationType);	//While most enums are int types, it is safer to not assume, so we use object types instead.
				for (int i = 0; i < enumTypeValues.Length; i++)
				{
					items.add(new System.Web.UI.WebControls.ListItem(enumTypeNames[i], enumTypeValues[i].ToString()));
				}
			}
		}
	}
