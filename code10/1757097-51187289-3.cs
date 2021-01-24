    var root = new RootObject();
    root.Name = sd.Engine_name;
    root.Tags = new List
    {
        new Tag {SensorName = sensor.Name}
    };
    var datapoints = new List<List<object>>();
	while (reader.Read()) 
    {
		datapoints.Add(new List<object>{
			Convert.ToString(reader["time"]), 
			Convert.ToSingle(reader["value"])
		});
	}
    root.Datapoints = datapoints;
    var json = JsonConvert.SerializeObject(root, Formatting.Indented);
