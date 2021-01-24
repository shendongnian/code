	void Main()
	{
		string nameOfFeature = "Second Wind";
		JObject jObject = JObject.Parse(data)["Fighter Features"] as JObject;
		foreach (JProperty feature in jObject.Properties())
		{
			if (feature.Name == nameOfFeature)
			{
				JObject secondWind = feature.Value as JObject;
				foreach (JProperty fProperty in secondWind.Properties())
				{
					Console.WriteLine (fProperty.Name + ": " + fProperty.Value);
				}
			}
		}
	}
