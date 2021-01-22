	public xyzFactory : DynamicObject
	{
		private static xyzFactory _instance = new xyzFactory();
		private xyzFactory() { }
		public static dynamic Instance
		{
			get{ return _instance; }
		}
		public override bool TryGetMember(GetMemberBinder binder, out object result) {
			// ...
		}
	}
