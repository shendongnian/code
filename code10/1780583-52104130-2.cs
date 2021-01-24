	public class RootObject
	{
		[JsonProperty("prospects")]
		public Dictionary<string, NameModel> Prospects { get; set; }
	}
	public class NameModel
	{
		[JsonProperty("firstName")]
		public string FirstName { get; set; }
		[JsonProperty("lastName")]
		public string LastName { get; set; }
	}
