    IEnumerable<object> measurements = // Get a combined enumerable with both measurement types.
	var settings = new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat };
	var json = measturements
		.Select(m => JObject.FromObject(m))
		.GroupBy(j => (int)j["testTIN"])
		.Select(g => g.Aggregate(new JObject(),
								 (j1, j2) => { j1.Merge(j2, settings); return j1; })
				)
		.ToList();
