	// Get the results
	IEnumerable<MeasurementSet__NoStrata> measurements1 = GetNoStrataMeasurements(); // Get no-strata measurements.
	IEnumerable<MeasurementSet__MultiStrata> measurements2 = GetMultiStrataMeasurements(); // Get multistrata measurements.
	// Combine them into a single enumerable
	IEnumerable<object> measurements = measurements1.Cast<object>()
		.Concat(measurements2.Cast<object>());
	// Select serialization and merge settings
	var serializerSettings = new JsonSerializerSettings
	{
		// Put whatever you want here, e.g.
		NullValueHandling = NullValueHandling.Ignore,
	};
	var mergeSettings = new JsonMergeSettings 
	{ 
		// Required
		MergeArrayHandling = MergeArrayHandling.Concat,
		// Put whatever you want here, either Ignore or Merge
		// https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_Linq_MergeNullValueHandling.htm
		MergeNullValueHandling = MergeNullValueHandling.Ignore, // Or Merge if you prefer
	};
	
	// Serialize and merge the results
	var serializer = JsonSerializer.CreateDefault(serializerSettings);
	var json = measurements
		.Select(m => JObject.FromObject(m, serializer))
		.GroupBy(j => (string)j["testTIN"])
		.Select(g => g.Aggregate(new JObject(),
								 (j1, j2) => { j1.Merge(j2, mergeSettings); return j1; })
				)
		// Do we need to remove the `"category"` property?
		// If so do it here.
		.Select(o => { o.Remove("category"); return o; })
		.ToList();
			
