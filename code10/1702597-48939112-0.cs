	void Main()
	{
		// Create dummy data
		var results = new List<StatsVm>();
		results.Add(new StatsVm { TotalCount = 10, Name = "John", LoggedDate = new DateTime(2018, 1, 1) });
		results.Add(new StatsVm { TotalCount = 20, Name = "Jane", LoggedDate = new DateTime(2018, 1, 1) });
		results.Add(new StatsVm { TotalCount = 15, Name = "Oliver", LoggedDate = new DateTime(2018, 2, 1) });
		results.Add(new StatsVm { TotalCount = 31, Name = "Kurt", LoggedDate = new DateTime(2018, 2, 1) });
		results.Add(new StatsVm { TotalCount = 23, Name = "Mike", LoggedDate = new DateTime(2018, 2, 5) });
		results.Add(new StatsVm { TotalCount = 18, Name = "Kath", LoggedDate = new DateTime(2018, 2, 8) });
		results.Add(new StatsVm { TotalCount = 19, Name = "Pearl", LoggedDate = new DateTime(2018, 2, 8) });
		results.Add(new StatsVm { TotalCount = 26, Name = "Charles", LoggedDate = new DateTime(2018, 2, 8) });
	
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
