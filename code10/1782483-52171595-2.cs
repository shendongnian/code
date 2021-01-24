	public class WorkSheet
	{
		[JsonConstructor]
		private WorkSheet() { }
		
		public WorkSheet(string name, int captionln)
		{
			wsName = name;
			captionLineNumber = captionln;
		}
        // Remainder unchanged
	}
