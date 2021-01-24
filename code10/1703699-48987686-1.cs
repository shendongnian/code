	public class Rootobject
	{
        [JsonProperty("odata.metadata")]
		public string odatametadata { get; set; }
		public Value[] value { get; set; }
	}
	public class Value
	{
		public string ItemCode { get; set; }
		public string ItemName { get; set; }
		public float QuantityOnStock { get; set; }
	}
    var items = JsonConvert.DeserializeObject<Rootobject>(json);
