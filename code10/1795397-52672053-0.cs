	public class SerializedClass
	{
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
		[JsonConverter(typeof(ArrayEnumConverter))]
		public SampleEnum SampleEnum { get; set; }
	}
