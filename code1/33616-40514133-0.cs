	[Serializable]
	public class c_Settings
	{
		static c_Settings Default;
		public static SetExistingObject(c_Settings def)
		{
			Default = def;
		}
		public string Prop1;
		public bool Prop2;
		public c_Settings()
		{
			if (Default == null)
				return;
			MemberInfo[] members = FormatterServices.GetSerializableMembers(typeof(c_Settings));
			FormatterServices.PopulateObjectMembers(this, members, FormatterServices.GetObjectData(Default, members));
		}
	}
