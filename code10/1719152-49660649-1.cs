	public partial class JsonsoftExample
	{
		public JsonsoftExample() { }
		[JsonConstructor]		
		JsonsoftExample(DateTime start, DateTime? end)
		{
			this.Start = start;
			this.End = end ?? Start.AddHours(1);			
		}
		
		[JsonProperty(Required = Required.Always)]
		public DateTime Start { get; set; }
	
		public DateTime End { get; set; }
	}
