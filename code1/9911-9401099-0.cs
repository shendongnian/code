	class TypedefString // Example with a string "typedef"
	{
		private string Value = "";
		public static implicit operator string(TypedefString ts)
		{
			return ((ts == null) ? null : ts.Value);
		}
		public static implicit operator TypedefString(string val)
		{
			return new TypedefString { Value = val };
		}
	}
