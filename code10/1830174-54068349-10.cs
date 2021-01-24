	var settings = new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat };
	var json = measurements
		.Select(j => JObject.Parse(j))
		.GroupBy(j => (int)j["testTIN"])
		.Select(g => g.Aggregate(new JObject(),
								 (j1, j2) => { j1.Merge(j2, settings); return j1; })
				)
		.ToList();
