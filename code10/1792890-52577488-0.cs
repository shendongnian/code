	public static void Main()
	{
		var records = new []
		{
			new Record {Name = "DT5227", Vload = 0, Sload = 270.5, Timestamp = "18-09-2018 31:22 PM" },
			new Record {Name = "DT5227", Vload = 254.1, Sload = 270.5, Timestamp = "19-09-2018 31:22 PM" },
			new Record {Name = "DT5227", Vload = 264.1, Sload = 270.5, Timestamp = "19-09-2018 33:22 PM" }
		};
		
		var results = records.GroupBy(x => x.Name).Select(x => x.OrderByDescending(r => r.Timestamp).Take(2).Select(r => r.Vload).Average());
		
		Console.WriteLine(results.First());
	}
