	// Concatenate the named files together into a single `JObject`:
	var settings = new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat };
	var json = fileNames.Aggregate(new JObject(),
								   (j, s) => 
								   { 
									   using (var file = File.OpenText(s))
									   using (var reader = new JsonTextReader(file))
									   {
										   j.Merge(JToken.Load(reader), settings);
									   }
									   return j; 
								   });
			
