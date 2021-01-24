	private List<Member> GetMembers(object instance)
	{
		var memberList = new List<Member>();
		foreach (var propertyInfo in instance.GetType().GetProperties())
		{
			var childMembers = new List<Member>(); // Moved to here, so it's not shared among all propertyInfo iterations.
			var member = new Member
			{
				Name = propertyInfo.PropertyType.IsList() ? propertyInfo.Name + "[]" : propertyInfo.Name,
				Type = SetPropertyType(propertyInfo.PropertyType),
			};
			if (propertyInfo.PropertyType.IsEnum)
			{
				member.Members = GetEnumValues(propertyInfo).ToArray();
			}
			if (propertyInfo.PropertyType.BaseType == typeof(ModelBase))
			{
				var childInstance = propertyInfo.GetValue(instance) ?? Activator.CreateInstance(propertyInfo.PropertyType);
				childMembers.AddRange(GetMembers(childInstance));
				member.Members = childMembers.ToArray();
			}
			if (propertyInfo.PropertyType.IsGenericType && (propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(List<>) ||
				propertyInfo.PropertyType.GetGenericTypeDefinition() == typeof(IList<>)))
			{
				var itemType = propertyInfo.PropertyType.GetGenericArguments()[0];
				var childInstance = Activator.CreateInstance(itemType);
				childMembers.AddRange(GetMembers(childInstance));
				member.Members = childMembers.Distinct().ToArray();
			}
			memberList.Add(member);
		}
		return memberList;
	}
