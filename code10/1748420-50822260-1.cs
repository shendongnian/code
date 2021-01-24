	var sourceDict = source.ToDictionary(s => s.Id);
	foreach (var t in target)
	{
		MyDataModel s;
		if (sourceDict.TryGetValue(t.Id, out s))
		{
			t.Desc = s.Desc;
			t.Country = s.Country;
		}
	}
