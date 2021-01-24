	public class FileItem
	{
		public string Title { get; set; }
		public string Path { get; set; }
		public override string ToString()
		{
			return this.Title;
		}
	}
