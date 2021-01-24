	public static Dictionary<string, object> MakeSnapShotReflection()
	{
		PropertyInfo[] allPorperties = typeof(Details).GetProperties(BindingFlags.Public | BindingFlags.Static);
		return allPorperties.ToDictionary(key => key.Name, value => value.GetValue(null));
	}
