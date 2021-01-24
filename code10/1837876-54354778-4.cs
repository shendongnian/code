	public partial class Pages
	{
		public List<Page> Rows { get; set; }
		
		public override string ToString()
		{
			return string.Join("\r\n", this.Rows.Select(q=>q.ToString()).ToArray());
		}
	}
	public partial class Page
	{
		public long Id { get; set; }
		public List<string> Data { get; set; }
		
		public override string ToString()
		{
			return "ID: " + this.Id.ToString() + " - Data: " + string.Join(", ", this.Data.Select(q=>q.ToString()).ToArray());
		}
	}
