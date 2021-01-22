    private static Dictionary<Type, Dictionary<Enum, string>> enumMaps = null;
    public static string GetDescription(Enum value)
    {
        Type eType = value.GetType();
    	if (enumMaps == null)
    	{
    		enumMaps = new Dictionary<Type, Dictionary<Enum, string>> ();
    	}
        Dictionary<Enum, string> map;
    	if (enumMaps.ContainsKey(eType))
    	{
    		map = enumMaps[eType];
    	}
    	else
    	{
    		map = new Dictionary<Enum, string>();
    		foreach (Enum e in Enum.GetValues(eType))
    		{
    			FieldInfo fi = eType.GetField(e.ToString());
    			DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);
                map[e] = (attributes.Length > 0) ? attributes[0].Description : e.ToString();
    		}
    		enumMaps[eType] = map;
    	}
        return map[value];
    }
