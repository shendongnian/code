    public static class ExtensionMethods
	{
		static public string GetDescription(this OrderStatus This)
		{
			var type = typeof(OrderStatus);
			var memInfo = type.GetMember(This.ToString());
			var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
			return ((DescriptionAttribute)attributes[0]).Description;
		}
	}
