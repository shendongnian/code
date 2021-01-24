    var settings = new ConnectionSettings(new Uri("http://distribution.virk.dk/cvr-permanent"));
    var client = new ElasticClient(settings);
    // get mappings for all indexes and types
    var mappings = client.GetMapping<JObject>(c => c.AllIndices().AllTypes());
    foreach (var indexMapping in mappings.Indices) {
        Console.WriteLine($"Index {indexMapping.Key.Name}"); // index name
        foreach (var typeMapping in indexMapping.Value.Mappings) {
            Console.WriteLine($"Type {typeMapping.Key.Name}"); // type name
            foreach (var property in typeMapping.Value.Properties) { 
                // property name and type. There might be more useful info, check other properties of `typeMapping`
                Console.WriteLine(property.Key.Name + ": " + property.Value.Type);
                // some properties are themselves objects, so you need to go deeper
                var subProperties = (property.Value as ObjectProperty)?.Properties;
                if (subProperties != null) {
                    // here you can build recursive function to get also sub-properties
                }
            }
        }
    }
