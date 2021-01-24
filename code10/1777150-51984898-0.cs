	public class LogAction
    {
      // other properties
	  [JsonConverter(typeof(RawJsonConverter))]
      public string Request { get; set; }
	  [JsonConverter(typeof(RawJsonConverter))]
      public string Response { get; set; }
    }
