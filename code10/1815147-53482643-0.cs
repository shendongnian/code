	var format = "dd.MM.yyyy";
	var provider = CultureInfo.InvariantCulture;
	var list = new List<DateTime> {
		DateTime.ParseExact("01.11.2018", format, provider),
		DateTime.ParseExact("09.11.2018", format, provider),
		DateTime.ParseExact("10.11.2018", format, provider),
		DateTime.ParseExact("12.11.2018", format, provider),
		DateTime.ParseExact("13.11.2018", format, provider),
		DateTime.ParseExact("14.11.2018", format, provider),
		DateTime.ParseExact("16.11.2018", format, provider),
		DateTime.ParseExact("20.11.2018", format, provider),
		DateTime.ParseExact("21.11.2018", format, provider),
		DateTime.ParseExact("29.11.2018", format, provider),			
	};
	list.Sort();
	var n = list.Count;
	var rangelist = new List<Tuple<DateTime, DateTime>>(n);
	for (var i = 0; i < n; i++)
	{
		var min = list[i];
		var max = list[i];
		for (var j = i + 1; j < n; j++)
			if ((list[j] - max).TotalDays == 1)
				max = list[i = j];
			else
				break;
		rangelist.Add(new Tuple<DateTime, DateTime>(min, max));
	}
	foreach (var range in rangelist)
		Console.WriteLine(
			range.Item1.ToString(format, provider) + "-" +
			range.Item2.ToString(format, provider));
