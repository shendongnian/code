	public static FieldInfo GetFieldUnambiguous(this Type type, string name, BindingFlags flags)
	{
		if (type == null) throw new ArgumentNullException(nameof(type));
		if (name == null) throw new ArgumentNullException(nameof(name));
		flags |= BindingFlags.DeclaredOnly;
		while (type != null)
		{
			var field = type.GetField(name, flags);
			if (field != null)
			{
				return field;
			}
			type = type.BaseType;
		}
		throw new MissingMemberException(type.FullName, name);
	}
	public static PropertyInfo GetPropertyUnambiguous(this Type type, string name, BindingFlags flags
	{
		if (type == null) throw new ArgumentNullException(nameof(type));
		if (name == null) throw new ArgumentNullException(nameof(name));
		flags |= BindingFlags.DeclaredOnly;
		while (type != null)
		{
			var property = type.GetProperty(name, flags);
			if (property != null)
			{
				return property;
			}
			type = type.BaseType;
		}
		throw new MissingMemberException(type.FullName, name);
	}
