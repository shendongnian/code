    public class MyIndex : AbstractIndexCreationTask<Document, DocumentIndDto>
	{
		public MyIndex()
		{
			// Add fields that are used for filtering and sorting
			Map = docs =>
				from e in docs
				select new
				{
					Title = e.Title, 
					_ = e.RecentModifications.Select( x => CreateField ($"{nameof(Document.RecentModifications)}_{x.UserId}", x.Timestamp))
				};
		}
	}
	public class DocumentIndDto
	{
		public string Title { get; set; }
	    public Dictionary<string,DateTime> RecentModifications { get; set; }
	}
