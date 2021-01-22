	static Guid GetEnumGuid(this Enum e)
	{
		Type type = e.GetType();
		MemberInfo[] memInfo = type.GetMember(e.ToString());
		if (memInfo != null && memInfo.Length > 0)
		{
			object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumGuid),false);
			if (attrs != null && attrs.Length > 0)
				return ((EnumGuid)attrs[0]).Guid;
		}
		throw new ArgumentException("Enum " + e.ToString() + " has no EnumGuid defined!");
	}
