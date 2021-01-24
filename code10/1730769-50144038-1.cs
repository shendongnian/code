	public class MyCommentList
	{
		public string ReplyText { get; set; }
		
		[JsonProperty(ItemConverterType = typeof(SingleOrArrayConverter<Comment>))]
		public List<List<Comment>> ReplyData { get; set; }
		public string ReplyCode { get; set; }
	} 
