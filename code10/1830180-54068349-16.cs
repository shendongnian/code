	IEnumerable<MeasurementSet__NoStrata> measurements1 = GetNoStrataMeasurements(); // Get no-strata measurements.
	IEnumerable<MeasurementSet__MultiStrata> measurements2 = GetMultiStrataMeasurements(); // Get multistrata measurements.
	IEnumerable<object> measurements = measurements1.Cast<object>()
		.Concat(measurements2.Cast<object>());
	var settings = new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat };
	var json = measurements
		.Select(m => JObject.FromObject(m))
		.GroupBy(j => (string)j["testTIN"])
		.Select(g => g.Aggregate(new JObject(),
								 (j1, j2) => { j1.Merge(j2, settings); return j1; })
				)
		// Do we need to remove the `"category"` property?
		// If so do it here.
		.Select(o => { o.Remove("category"); return o; })
		.ToList();
			
