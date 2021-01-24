    	public static void FindStringMembers(Type t, List<string>PropertyNames, int stackDepth = 0) 
		{
			if (stackDepth >= 10) {
				return;
			}
			var f = t.GetProperties();
			var stringProperties = f.Where(x => x.PropertyType == typeof(string)).Select(x => x.Name);
			PropertyNames.AddRange(stringProperties);
			var otherProperties = f.Where(x => x.PropertyType != typeof(string));
			foreach (var property in otherProperties) {
				FindStringMembers(property.PropertyType, PropertyNames, stackDepth + 1);
			}
		}
		static void Main(string[] args)
		{
			var bob = new Person();
			var deepScan = new List<string>();
			FindStringMembers(bob.GetType(), deepScan);
			Console.WriteLine(string.Join("\n", deepScan));
		}
