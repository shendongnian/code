	[JsonProperty("prices")]
	public List<Price> prices { get; set; }
	//...
	class Price 
	{
		[JsonProperty("name")]
		public string Name {get;set;}
		[JsonProperty("value")]
		public float? Value {get;set;}
		//...
	}
