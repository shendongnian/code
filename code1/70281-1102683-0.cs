	public class FormatDescription : Attribute
	{
		public string Description { get; private set; }
		
		public FormatDescription(string description)
		{
			Description = description;
		}
	}
