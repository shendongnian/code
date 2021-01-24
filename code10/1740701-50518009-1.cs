	List<double> positions = new List<double>();
	List<double> players = new List<double>();
	foreach (string element in fractionedList)
	{
        string[] elementSplit = element.Split(',');
        positions.AddRange(elementSplit.Skip(2).Take(3).Select(x => double.Parse(x));
        players.AddRange(elementSplit.Skip(5).Take(3).Select(x => double.Parse(x)); 
	} 
