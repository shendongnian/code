	// Load the JSON without parsing or converting any dates.
	var model = JsonConvert.DeserializeObject<JObject>(data, new JsonSerializerSettings{ DateParseHandling = DateParseHandling.None });
	// Construct a serializer that converts all DateTime values to UTC
	var serializer = JsonSerializer.CreateDefault(new JsonSerializerSettings{ DateTimeZoneHandling = DateTimeZoneHandling.Utc });
	
	foreach (var locations in model.SelectTokens("Result[*].locations").OfType<JArray>())
	{
		// Then sort the locations by utcDate converting the value to UTC at this time.
		var query = from location in locations
					let utcDate = location.SelectToken("locTypeAttributes.utcDate").ToObject<DateTime>(serializer)
					orderby utcDate
					select location;
		locations.ReplaceAll(query.ToList());
	}
