    var person = new Person();
    // Create and add a converter which will use the string representation instead of the numeric value.
    var stringEnumConverter = new System.Text.Json.Serialization.JsonStringEnumConverter();
	JsonSerializerOptions opts = new JsonSerializerOptions();
	opts.Converters.Add(stringEnumConverter);
    // Generate json string.
	var json = JsonSerializer.Serialize<Person>(person, opts); 
