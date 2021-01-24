    [JsonProperty("prices")]
    public Price prices { get; set; }
    //...
	class Price 
	{
		[JsonProperty("students")]
		public float? Students{get;set;}
		[JsonProperty("employees")]
		public float? Employees{get;set;}
		[JsonProperty("pupils")]
		public float? Pupils{get;set;}
		[JsonProperty("prices")]
		public float? Others{get;set;}
		//...
	}
