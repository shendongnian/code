	public static void Main()
	{
		var json = "[ { \"transactionId\": 1778, \"locName\": \"IL\", }, { \"transactionId\": 1779, \"locName\": \"NY\", }, { \"transactionId\": 1774, \"locName\": \"IL\", }, { \"transactionId\": 1771, \"locName\": \"NY\" }, null ]";
		
		var list = JsonConvert.DeserializeObject<List<Entity>>(json, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
	}
	
	public class Entity
	{
		public string TransactionId { get; set; }
		public string LocName { get; set; }
	}
