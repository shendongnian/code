    IEnumerable<QualityMeasureValue_NoStrata> measurements1 = null; // Get no-strata measurements.
    IEnumerable<MeasurementSet__MultiStrata> measurements2 = null; // Get multistrata measurements.
    IEnumerable<object> measurements = measurements1.Cast<object>()
		.Concat(measurements2.Cast<object>());
	var settings = new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat };
	var json = measurements
		.Select(m => JObject.FromObject(m))
		.GroupBy(j => (int)j["testTIN"])
		.Select(g => g.Aggregate(new JObject(),
								 (j1, j2) => { j1.Merge(j2, settings); return j1; })
				)
		.ToList();
