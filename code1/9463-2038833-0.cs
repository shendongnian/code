	[Obsolete("Mapping ToDo")]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
	public class MappingToDo : System.Attribute
	{
		public string Comment = "";
		
		public MappingToDo(string comment)
		{
			Comment = comment;
		}
		public MappingToDo()
		{}
	}
