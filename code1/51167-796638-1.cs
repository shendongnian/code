	public static IDictionary<T, string> GetDescriptions<T>()
		where T : struct
	{
		IDictionary<T, string> values = new Dictionary<T, string>();
		Type type = enumerationValue.GetType();
		if (!type.IsEnum)
		{
			throw new ArgumentException("T must be of Enum type", "enumerationValue");
		}
		//Tries to find a DescriptionAttribute for a potential friendly name
		//for the enum
		foreach (T value in Enum.GetValues(typeof(T)))
		{
			string text = value.GetDescription();
			values.Add(value, text);
		}
		return values;
	}
