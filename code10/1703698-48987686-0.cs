	public class Rootobject
	{
		public string odatametadata { get; set; }
		public Item[] items { get; set; }
	}
	public class Item
	{
		[JsonProperty(PropertyName = "ItemCode")]
		public string ItemCode { get; set; }
		[JsonProperty(PropertyName = "ItemName")]
		public string ItemName { get; set; }
		[JsonProperty(PropertyName = "QuantityOnStock")]
		public float QuantityOnStock { get; set; }
	}
