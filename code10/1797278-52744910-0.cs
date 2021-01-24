	[JsonConverter(typeof(ObjectToArrayConverter<Full_Result>))]
	public class Full_Result 
	{
		[JsonProperty(Order = 1)]
		public IList<string> values { get; set; }
		[JsonProperty(Order = 2)]
		public float score { get; set; }
	}
