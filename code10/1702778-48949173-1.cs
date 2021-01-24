	public async System.Threading.Tasks.Task<Dictionary<int, decimal>> ReadProtobuffAsync()
	{
		using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
		using (System.IO.Stream responseStream = await client.GetStreamAsync("http://localhost:53204/ProtobuffToString"))
		{
			// deserialize directly from the response stream
			return ProtoBuf.Serializer.Deserialize<Dictionary<int, decimal>>(responseStream));
		}
	}
