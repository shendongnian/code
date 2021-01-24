	// Deserialize the JSON shown in the question to an array of objects with Namespace and Name properties
    var list = JsonConvert.DeserializeAnonymousType(
		jsonString, 
		new[] { new { Namespace = default(string), Name = default(string) } });
    var root = new Namespace();
    foreach (var item in list)
    {
		// Split the Namespace property into an array for recursive processing
        root.AddObject(item.Namespace.Split('.'), item.Name);
    }
