	class Item
	{
		[JsonProperty("id")]
		public string Id { get; set; }
		[JsonProperty("key")]
		public string Key { get; set; }
		[JsonProperty("states")]
		public List<string> States { get; set; }
	}
