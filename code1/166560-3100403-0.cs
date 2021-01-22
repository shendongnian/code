	public static IList<MemberInfo> GetMethodsImplementing<T>(Assembly assembly) where T : Attribute
	{
		var result = new List<MemberInfo>();
		var types = assembly.GetTypes();
		foreach (var type in types)
		{
			if (!type.IsClass) continue;
			var members = type.GetMembers();
			foreach (var member in members)
			{
				if (member.MemberType != MemberTypes.Method)
					continue;
				var attributes = member.GetCustomAttributes(typeof(T), true /*inherit*/);
				if (attributes.Length > 0)
				{
					// yup. This method implementes MyAttribute
					result.Add(member);
				}
			}
		}
		return result;
	}
