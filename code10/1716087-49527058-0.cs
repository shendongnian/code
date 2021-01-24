    public class DescriptionAttribute : Attribute
	{
		public string Name { get; }
		public DescriptionAttribute(string name)
		{
			Name = name;
		}
	}
