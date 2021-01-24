    public class RootObject
	{
		[JsonConverter(typeof(IgnoreEmptyItemsConverter<string>))]
		public List<string> Highlights { get; set; }
	}
