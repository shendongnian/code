	using (StreamReader r = new StreamReader("test.json"))
	{
		string json = r.ReadToEnd();
		List<DataToBeSent> items = JsonConvert.DeserializeObject<List<DataToBeSent>>(json);
		foreach (var item in items)
		{
			SendItemOverNetwork(JsonConvert.SerializeObject(item));
		}
	}
   	public class DataToBeSent
	{
		public int CombinationCode { get; set; }
		public string Pattern { get; set; }
	}
