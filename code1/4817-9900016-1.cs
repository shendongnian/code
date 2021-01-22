	public static System.Web.UI.WebControls.ListItem[] EnumToDropDownList<TEnum>() where TEnum : struct
	{
		System.Type enumerationType = typeof(TEnum);
	
		if (!enumerationType.IsEnum) throw new ArgumentException("Enumeration type is expected.");
	
		string[] saveResponseTypeNames = System.Enum.GetNames(enumerationType);
		dynamic saveResponseTypeValues = System.Enum.GetValues(enumerationType);
		System.Web.UI.WebControls.ListItem[] outputListItems = new System.Web.UI.WebControls.ListItem[saveResponseTypeNames.Length];
	
		for (i = 0; i <= saveResponseTypeNames.Length - 1; i++) {
			outputListItems[i] = new System.Web.UI.WebControls.ListItem(saveResponseTypeNames[i], saveResponseTypeValues(i).ToString());
		}
	
		return outputListItems;
	}
