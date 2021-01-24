    public static class TypeExtensions
	{
		public static MemberInfo[] GetMembersInclPrivateBase(this Type t, BindingFlags flags)
		{
			var memberList = new List<MemberInfo>();
			memberList.AddRange(t.GetMembers(flags));
			Type currentType = t;
			while((currentType = currentType.BaseType) != null)
				memberList.AddRange(currentType.GetMembers(flags));
			return memberList.ToArray();
		}
	}
