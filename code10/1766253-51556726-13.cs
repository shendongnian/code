	public static Dictionary<string, object> MakeSnapShotReflection()
	{
		PropertyInfo [] allPorperties = typeof(Details).GetProperties(BindingFlags.Public | BindingFlags.Static);
		
		Dictionary<string, object> valuemapping = new Dictionary<string, object>();
		
		for (int i = 0; i < allPorperties.Length; i++)
		{
			valuemapping.Add(allPorperties[i].Name, allPorperties[i].GetValue(null));
		}
		
		return valuemapping;
	}
