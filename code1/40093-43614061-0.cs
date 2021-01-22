    public class ClassLikeEnum
	{
		public string Value
		{
			get;
			private set;
		}
		ClassLikeEnum(string value) 
		{
			Value = value;
		}
		public static implicit operator string(ClassLikeEnum c)
		{
			return c.Value;
		}
		public static readonly ClassLikeEnum C1 = new ClassLikeEnum("RandomString1");
		public static readonly ClassLikeEnum C2 = new ClassLikeEnum("RandomString2");
	}
