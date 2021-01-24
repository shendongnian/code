	void Main()
	{
		JObject jObject = JObject.Parse(data);
		var fighterFeatures = jObject["Fighter Features"].Children().ToList();
		foreach (JToken jToken in fighterFeatures)
		{
			var feature = jToken.First() as JObject;
			foreach (JProperty prop in feature.Properties())
			{
				Console.WriteLine (prop.Name + ": " + prop.Value);
			}
			
			Console.WriteLine ();
		}
	}
