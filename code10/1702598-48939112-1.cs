	void Main()
	{
		// Create dummy data
		var results = new List<StatsVm>();
		// Create dummy data
		var results = new List<StatsVm>();
		results.Add(new StatsVm { TotalCount = 20, Name = "Test", LoggedDate = new DateTime(2018, 1, 1) });
		results.Add(new StatsVm { TotalCount = 1, Name = "Test2", LoggedDate = new DateTime(2018, 1, 1) });
		results.Add(new StatsVm { TotalCount = 20, Name = "Test", LoggedDate = new DateTime(2018, 1, 2) });
		results.Add(new StatsVm { TotalCount = 1, Name = "Test2", LoggedDate = new DateTime(2018, 1, 2) });
	
		// Creates the dictionary
		var output = results
			.Select(r => new
			{
				LoggedDate = r.LoggedDate.GetValueOrDefault().ToString("yyyy-MM-dd"),
				Name = r.Name,
				TotalCount = r.TotalCount
			})
			.GroupBy(group => group.LoggedDate)
			.ToDictionary(t => t.Key);
	
		// Serializes the dictionary as a JSON string
		var serializedString = JsonConvert.SerializeObject(output, Newtonsoft.Json.Formatting.Indented);
	
		// Prints the serialized string
		Console.WriteLine(serializedString);
	}
	
	public class StatsVm
	{
	
		public int TotalCount { get; set; }
		public string Name { get; set; }
		public DateTime? LoggedDate { get; set; }
	}
