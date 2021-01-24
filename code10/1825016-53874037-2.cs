	[CompilerGenerated]
	[Serializable]
	private sealed class <>c
	{
		public static readonly Program.<>c <>9 = new Program.<>c();
		public static Func<Type, IEnumerable<FieldInfo>> <>9__0_0;
		public static Func<FieldInfo, bool> <>9__0_1;
		internal IEnumerable<FieldInfo> <Main>b__0_0(Type x)
		{
			return x.GetFields(BindingFlags.Instance | BindingFlags.Public);
		}
		internal bool <Main>b__0_1(FieldInfo x)
		{
			return x.IsPublic;
		}
	}
