	public static void Main()
	{
		Console.WriteLine(FindProperty("SubClass", new List<long>() { 156346 }));
		Console.WriteLine(FindProperty("SubClass", new List<long>() { 1 }));
		Console.WriteLine(FindProperty("SubClass2", new List<long>() { 280114157 }));
		//True
		//False
		//True
	}
	public static bool FindProperty<T>(string subClassName, IEnumerable<T> toFind)
	{
		var consts = GetConsts<T>(subClassName);
        //The logic here may not be exactly what you need, 
        //but this is just an example
		return toFind.Any(x => consts.Contains(x));
	}
	static IEnumerable<T> GetConsts<T>(string subClassName)
	{
		var allTypes = Assembly.GetExecutingAssembly().GetTypes();
		var myType = allTypes.FirstOrDefault(t => t.Name.EndsWith(subClassName));
		if (myType == null)
		{
			return Enumerable.Empty<T>();
		}
		var consts = GetConstants(myType);
		var first = consts.First();
		var constsOfTypeT = consts
			.Where(c => c.FieldType == typeof(T));
		return constsOfTypeT
			.Select(c => (T)c.GetRawConstantValue());
	}
	/// <summary>
	/// From https://stackoverflow.com/questions/10261824/how-can-i-get-all-constants-of-a-type-by-reflection#10261848
	/// by gdoron
	/// </summary>
	private static List<FieldInfo> GetConstants(Type type)
	{
		FieldInfo[] fieldInfos = type.GetFields(BindingFlags.Public |
			 BindingFlags.Static | BindingFlags.FlattenHierarchy);
		return fieldInfos.Where(fi => fi.IsLiteral && !fi.IsInitOnly).ToList();
	}
