	// Get the initial measurement JSON measurements as strings.
	IEnumerable<string> measturements = GetJsonMeasurements();
	// And concatenate them together into a combined `JObject`:
	var settings = new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat };
	var json = measturements.Aggregate(new JObject(),
									   (j, s) => { j.Merge(JObject.Parse(s), settings); return j; });
