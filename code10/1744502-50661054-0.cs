	public class TransactionResponse
	{
		[JsonExtensionData]
		[JsonIgnore]
		public JObject AdditionalData { get; set; }
		[JsonIgnore]
		public JValue RawTransaction { get; set; }
		[OnDeserialized]
		internal void OnDeserialized(StreamingContext ctx)
		{
			var ser = (JValue)JsonConvert.SerializeObject(this);
			AdditionalData.Merge(ser);
			RawTransaction = ser;
		}
        public decimal Amount { get; set; }
