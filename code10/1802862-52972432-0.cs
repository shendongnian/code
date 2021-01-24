	var listDate = new List<DateTime>();
	listDate.Add(new DateTime(1980, 5, 5));
	listDate.Add(new DateTime(1982, 10, 20));
	listDate.Add(new DateTime(1984, 1, 4));
	listDate.Add(new DateTime(1979, 6, 19));
	var result = listDate.Select(x => new { property1 = x.ToString("MMMM yyyy, dd"), property2 = x });
	foreach (var d in result)
	{
		Console.WriteLine(d.property1);
	}
	
