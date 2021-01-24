	var data = new[] {
		new { Name="Hello", Hours=40, Rate=12M, Owed = 0M }
	,	new { Name="World", Hours=30, Rate=20M, Owed = 100M }
	,	new { Name="Fiz Buz, Jr.", Hours=44, Rate=8M, Owed = 80M }
	};
	foreach (var e in data) {
		Console.WriteLine("{0,-20}\t{1,4:####}\t{2,7:c}\t{3,10:c}", e.Name, e.Hours, e.Rate, e.Owed);
	}
