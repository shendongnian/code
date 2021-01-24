	void Main()
	{
		var line = "00580011T3A1111        2999Bosh                                399APV                                2399MAG                           ";
	
		var lengths = new[] { 4, 4, 1, 1, 8, 9, 30, 9, 30, 9, 30 };
		var starts = lengths.Aggregate(new[] { 0 }.ToList(), (a, x) => { a.Add(a.Last() + x); return a; });
	
		var fields = starts.Zip(lengths, (p, l) => line.Substring(p, l).Trim()).ToArray();
	
		var message = new
		{
			message_length = int.Parse(fields[0]),
			message_id = int.Parse(fields[1]),
			message_type = fields[2],
			message_sequence = int.Parse(fields[3]),
			car_Id = fields[4],
			parts =
				Enumerable
					.Range(0, 3)
					.Select(x => x * 2 + 5)
					.Select(x => new Part
					{
						Price = decimal.Parse(fields[x]),
						Manufacturer = fields[x + 1]
					}).ToArray(),
		};
	}
	
	public class Part
	{
		public decimal Price { get; set; }
		public string Manufacturer { get; set; }
	}
